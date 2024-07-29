CREATE OR ALTER PROCEDURE dbo.ChangeRecipeStatus(
    @RecipeId INT,
    @NewStatus VARCHAR(50),
    @Message VARCHAR(500) OUTPUT
)
AS
BEGIN
    DECLARE @CurrentDate DATE = CAST(GETDATE() as date)

    SET @Message = ''

    IF NOT EXISTS (SELECT 1 FROM Recipe WHERE RecipeId = @RecipeId)
    BEGIN
        SET @Message = 'Recipe not found.'
        RETURN
    END

    IF @NewStatus = 'Drafted'
    BEGIN
        UPDATE Recipe
        SET DateDrafted = @CurrentDate
        WHERE RecipeId = @RecipeId
        SET @Message = 'Recipe status changed to Drafted.'
    END
    ELSE IF @NewStatus = 'Published'
    BEGIN
        UPDATE Recipe
        SET DatePublished = @CurrentDate
        WHERE RecipeId = @RecipeId
        SET @Message = 'Recipe status changed to Published.'
    END
    ELSE IF @NewStatus = 'Archived'
    BEGIN
        UPDATE Recipe
        SET DateArchived = @CurrentDate
        WHERE RecipeId = @RecipeId
        SET @Message = 'Recipe status changed to Archived.'
    END
    ELSE
    BEGIN
        SET @Message = 'Invalid status provided.'
        RETURN
    END
END
GO
