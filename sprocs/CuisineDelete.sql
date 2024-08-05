create or alter procedure dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

 DECLARE @RecipeId INT;
        DECLARE RecipeCursor CURSOR FOR 
        SELECT RecipeId 
        FROM Recipe 
        WHERE CuisineId = @CuisineId;

        OPEN RecipeCursor;
        FETCH NEXT FROM RecipeCursor INTO @RecipeId;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            DELETE FROM RecipeSteps WHERE RecipeId = @RecipeId;

            DELETE FROM RecipeIngredient WHERE RecipeId = @RecipeId;

            DELETE FROM CookbookRecipe WHERE RecipeId = @RecipeId;

            DELETE FROM MealCourseRecipe WHERE RecipeId = @RecipeId;

            DELETE FROM Recipe WHERE RecipeId = @RecipeId;

            FETCH NEXT FROM RecipeCursor INTO @RecipeId;
        END

        CLOSE RecipeCursor;
        DEALLOCATE RecipeCursor;

        DELETE FROM Cuisine WHERE CuisineId = @CuisineId;

        COMMIT;

        SET @Message = 'Cuisine deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH

    return @return 
    
END 
GO

DECLARE @id INT;
SELECT TOP 1 @id = CuisineId FROM Cuisine;
DECLARE @Message VARCHAR(500);

EXEC dbo.CuisineDelete @CuisineId = @id, @Message = @Message OUTPUT;

SELECT @Message;

