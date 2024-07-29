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
            -- Delete related RecipeSteps
            DELETE FROM RecipeSteps WHERE RecipeId = @RecipeId;

            -- Delete related RecipeIngredients
            DELETE FROM RecipeIngredient WHERE RecipeId = @RecipeId;

            -- Delete related CookbookRecipes
            DELETE FROM CookbookRecipe WHERE RecipeId = @RecipeId;

            -- Delete related MealCourseRecipes
            DELETE FROM MealCourseRecipe WHERE RecipeId = @RecipeId;

            -- Delete the recipe itself
            DELETE FROM Recipe WHERE RecipeId = @RecipeId;

            FETCH NEXT FROM RecipeCursor INTO @RecipeId;
        END

        CLOSE RecipeCursor;
        DEALLOCATE RecipeCursor;

        -- Delete the Cuisine itself
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

