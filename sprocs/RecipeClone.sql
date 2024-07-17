CREATE OR ALTER PROCEDURE dbo.CloneRecipe(
    @RecipeId INT,
    @NewRecipeId INT OUTPUT,
    @Message VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CuisineId INT,
            @UsersId INT,
            @RecipeName VARCHAR(100),
            @Calories INT,
            @DateDrafted DATETIME2,
            @DatePublished DATETIME2,
            @DateArchived DATETIME2;

    -- Retrieve the existing recipe details
    SELECT @CuisineId = CuisineId,
           @UsersId = UsersId,
           @RecipeName = RecipeName,
           @Calories = Calories,
           @DateDrafted = DateDrafted,
           @DatePublished = DatePublished,
           @DateArchived = DateArchived
    FROM Recipe
    WHERE RecipeId = @RecipeId;

    IF @RecipeName IS NULL
    BEGIN
        SET @Message = 'Recipe not found';
        RETURN;
    END

    -- Append " - clone" to the RecipeName
    SET @RecipeName = @RecipeName + ' - clone';

    -- Insert the new recipe
    INSERT INTO Recipe (CuisineId, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
    VALUES (@CuisineId, @UsersId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived);

    -- Retrieve the new RecipeId
    SET @NewRecipeId = SCOPE_IDENTITY();

    SET @Message = 'Recipe cloned successfully';

    RETURN;
END;
GO
