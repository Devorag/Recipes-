CREATE OR ALTER PROCEDURE dbo.RecipeDelete
    @RecipeId INT,
    @Message VARCHAR(500) = '' OUTPUT 
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @return INT = 0;

    IF NOT EXISTS (
        SELECT *
        FROM Recipe r 
        WHERE r.RecipeId = @RecipeId AND
              (r.RecipeStatus = 'Drafted' or DATEDIFF(day, r.DateArchived, GETDATE()) >= 30)
    )
    BEGIN
        select @return = 1, @Message = 'Can only delete a recipe that is currently drafted or that has been archived in over 30 days.'
        GOTO finished
    END


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
        
        SET @Message = ERROR_MESSAGE();
        SET @return = 1;
 END CATCH
 
    finished:
    RETURN @return;
END
GO
