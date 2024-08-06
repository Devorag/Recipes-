CREATE OR ALTER PROCEDURE dbo.ChangeRecipeStatus(
    @RecipeId INT,
    @NewStatus VARCHAR(50),
    @Message VARCHAR(500) OUTPUT
)
AS
BEGIN
    DECLARE @CurrentDate DATE = CAST(GETDATE() as date)
    DECLARE @CurrentStatus VARCHAR(50)

    SET @Message = ''

    IF NOT EXISTS (SELECT 1 FROM Recipe WHERE RecipeId = @RecipeId)
    BEGIN
        SET @Message = 'Recipe not found.'
        RETURN
    END

    SELECT @CurrentStatus = 
        CASE 
            WHEN DateArchived IS NOT NULL THEN 'Archived'
            WHEN DatePublished IS NOT NULL THEN 'Published'
            WHEN DateDrafted IS NOT NULL THEN 'Drafted'
        END
    FROM Recipe
    WHERE RecipeId = @RecipeId


    IF @NewStatus = 'Drafted'
    BEGIN
        IF @CurrentStatus = 'Published' OR @CurrentStatus = 'Archived'
        BEGIN
            UPDATE Recipe
            SET DateDrafted = @CurrentDate,
                DatePublished = null,
                DateArchived = null
            WHERE RecipeId = @RecipeId
            SET @Message = 'Recipe status changed to Drafted.'
        END
        ELSE
        BEGIN
            SET @Message = 'Cannot change to Drafted from the current status.'
            RETURN
        END
    END
    ELSE IF @NewStatus = 'Published'
    BEGIN
        IF @CurrentStatus = 'Archived' OR @CurrentStatus = 'Drafted'
        BEGIN
            UPDATE Recipe
            SET DatePublished = @CurrentDate,
                DateArchived = CASE WHEN @CurrentStatus = 'Archived' THEN NULL ELSE DateArchived END,
                DateDrafted = DateDrafted
            WHERE RecipeId = @RecipeId
            SET @Message = 'Recipe status changed to Published.'
        END
        ELSE
        BEGIN
            SET @Message = 'Cannot change to Published from the current status.'
            RETURN
        END
    END
    ELSE IF @NewStatus = 'Archived'
    BEGIN
        IF @CurrentStatus <> 'Archived'
        BEGIN
            UPDATE Recipe
            SET DateArchived = @CurrentDate,
                DatePublished = DatePublished,
                DateDrafted = DateDrafted
            WHERE RecipeId = @RecipeId
            SET @Message = 'Recipe status changed to Archived.'
        END
        ELSE
        BEGIN
            SET @Message = 'Recipe is already Archived.'
            RETURN
        END
    END
END
GO
