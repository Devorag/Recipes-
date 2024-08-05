create or alter procedure dbo.CourseDelete(
    @CourseId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION

        DECLARE @MealCourseId INT;
        DECLARE MealCourseCursor CURSOR FOR 
        SELECT MealCourseId 
        FROM MealCourse 
        WHERE CourseId = @CourseId;

        OPEN MealCourseCursor;
        FETCH NEXT FROM MealCourseCursor INTO @MealCourseId;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            DELETE FROM MealCourseRecipe WHERE MealCourseId = @MealCourseId;

            DELETE FROM MealCourse WHERE MealCourseId = @MealCourseId;

            FETCH NEXT FROM MealCourseCursor INTO @MealCourseId;
        END

        CLOSE MealCourseCursor;
        DEALLOCATE MealCourseCursor;

        DELETE FROM Course WHERE CourseId = @CourseId;

        COMMIT;

        SET @Message = 'Course deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;

    return @return 
    end catch
END 
GO

DECLARE @id INT;
SELECT TOP 1 @id = CourseId FROM Course;
DECLARE @Message VARCHAR(500);

EXEC dbo.CourseDelete @CourseId = @id--, @Message = @Message OUTPUT;

SELECT @Message;
