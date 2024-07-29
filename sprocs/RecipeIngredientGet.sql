CREATE OR ALTER PROCEDURE dbo.RecipeIngredientGet(
    @RecipeIngredientId INT = 0,
    @RecipeId INT = 0,
    @All BIT = 0, 
    @Message VARCHAR(500) = '' OUTPUT
)
AS 
BEGIN 
    DECLARE @return INT = 0 

    SELECT @All = ISNULL(@All, 0), 
           @RecipeIngredientId = ISNULL(@RecipeIngredientId, 0), 
           @RecipeId = ISNULL(@RecipeId, 0)

    IF @All = 1
    BEGIN
        SELECT ri.RecipeIngredientId, 
               ri.RecipeId, 
               ri.IngredientId, 
               ri.UnitOfMeasureId, 
               ri.MeasurementAmount, 
               ri.IngredientSequence
        FROM RecipeIngredient ri 
        order by ri.ingredientsequence
    END
    ELSE IF @RecipeIngredientId > 0
    BEGIN
        SELECT ri.RecipeIngredientId, 
               ri.RecipeId, 
               ri.IngredientId, 
               ri.UnitOfMeasureId, 
               ri.MeasurementAmount, 
               ri.IngredientSequence
        FROM RecipeIngredient ri 
        WHERE ri.RecipeIngredientId = @RecipeIngredientId 
        order by ri.ingredientsequence
    END
    ELSE IF @RecipeId > 0
    BEGIN
        SELECT ri.RecipeIngredientId, 
               ri.RecipeId, 
               ri.IngredientId, 
               ri.UnitOfMeasureId, 
               ri.MeasurementAmount, 
               ri.IngredientSequence
        FROM RecipeIngredient ri 
        WHERE ri.RecipeId = @RecipeId
        order by ri.ingredientsequence 
    END

    RETURN @return 
END 
GO
