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

    SET @RecipeName = @RecipeName + ' - clone';

    INSERT INTO Recipe (CuisineId, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
    VALUES (@CuisineId, @UsersId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived);

    SET @NewRecipeId = SCOPE_IDENTITY();

    INSERT INTO RecipeIngredient (RecipeId, IngredientId, UnitOfMeasureId, MeasurementAmount, IngredientSequence)
    SELECT @NewRecipeId, IngredientId, UnitOfMeasureId, MeasurementAmount, IngredientSequence
    FROM RecipeIngredient
    WHERE RecipeId = @RecipeId;

    INSERT INTO RecipeSteps (RecipeId, Instructions, StepSequence)
    SELECT @NewRecipeId, Instructions, StepSequence
    FROM RecipeSteps 
    WHERE RecipeId = @RecipeId;

    SET @NewRecipeId = SCOPE_IDENTITY();

    SET @Message = 'Recipe cloned successfully';

    RETURN;
END;
GO
