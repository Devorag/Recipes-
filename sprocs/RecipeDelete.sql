CREATE OR ALTER PROCEDURE dbo.RecipeDelete
    @RecipeId INT,
    @Message VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @return INT = 0;

    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE from CookbookRecipe where RecipeId = @RecipeId
        Delete from MealCourseRecipe where RecipeId = @RecipeId
        DELETE FROM RecipeIngredient WHERE RecipeId = @RecipeId;
        DELETE FROM RecipeSteps WHERE RecipeId = @RecipeId;

        DELETE FROM Recipe WHERE RecipeId = @RecipeId;

        COMMIT;

        SET @Message = 'Recipe deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;

 END CATCH
    RETURN @return;
END
GO
