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
    BEGIN
        SELECT ri.RecipeIngredientId, 
               ri.RecipeId, 
               ri.IngredientId, 
               ri.UnitOfMeasureId, 
               ri.MeasurementAmount, 
               ri.IngredientSequence,
               i.IngredientName
        FROM RecipeIngredient ri 
        join Ingredient I 
        on i.ingredientId = ri.IngredientId 
		where @All = 1 
		or ri.RecipeIngredientId = @RecipeIngredientId 
		or ri.RecipeId = @RecipeId
        order by ri.ingredientsequence
    END

    RETURN @return 
END 
GO

exec RecipeIngredientGet @All =  1