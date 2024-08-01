CREATE OR ALTER PROCEDURE dbo.CookbookRecipeUpdate(
    @CookbookRecipeId INT OUTPUT,
    @CookbookId INT,    
    @RecipeId INT, 
    @RecipeSequence INT, 
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @return INT = 0;

--AS This will be blocked from error handling in the front end.
    IF @RecipeSequence <= 0
    BEGIN
        SET @Message = 'Invalid RecipeSequence.';
        SET @return = -1;
        RETURN @return;
    END

    SELECT @CookbookRecipeId = ISNULL(@CookbookRecipeId, 0), @RecipeId = ISNULL(@RecipeId,0), @RecipeSequence = ISNULL(@RecipeSequence,0);

    IF @CookbookRecipeId = 0
    BEGIN
        INSERT INTO CookbookRecipe (CookbookId, RecipeId, RecipeSequence)
        VALUES (@CookbookId, @RecipeId, @RecipeSequence);

        SET @CookbookRecipeId = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        UPDATE CookbookRecipe
        SET CookbookId = @CookbookId,
            RecipeId = @RecipeId, 
            RecipeSequence = @RecipeSequence
        WHERE CookbookRecipeId = @CookbookRecipeId;
    END

    RETURN @return;
END
GO
