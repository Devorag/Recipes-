create or alter procedure dbo.CourseDelete(
    @CourseId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related data
        delete from MealCourseRecipe where MealCourseId = @CourseId
        DELETE FROM MealCourse WHERE CourseId = @CourseId

        -- Delete recipe
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
