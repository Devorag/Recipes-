CREATE OR ALTER PROCEDURE dbo.RecipeDelete
    @RecipeId INT,
    @Message VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @return INT = 0;

    IF not EXISTS (
        SELECT 1
        FROM Recipe r 
        WHERE R.RecipeId = @RecipeId 
        AND
         (r.RecipeStatus = 'Drafted' 
               OR DATEDIFF(day, r.DateArchived, GETDATE()) >= 30 )
    )
   BEGIN
       SET @return = 1;
       SET @Message = 'Cannot delete recipe because it has not been archived for over 30 days or it is not currently drafted.';
       RETURN @return;
   END

  IF EXISTS (SELECT 1 FROM MealCourseRecipe MC WHERE MC.RecipeId = @RecipeId) OR
       EXISTS (SELECT 1 FROM CookbookRecipe cr WHERE cr.RecipeId = @RecipeId)
    BEGIN
        SET @return = 1;
        SET @Message = 'Recipe could not be deleted because it is part of a meal or cookbook.';
        RETURN @return;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

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
