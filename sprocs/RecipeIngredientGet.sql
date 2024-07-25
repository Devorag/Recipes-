create or alter procedure dbo.RecipeIngredientGet(
    @RecipeIngredientId int = 0,
    @RecipeId int = 0,
    @All bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @All = isnull(@All,0), @RecipeIngredientId = ISNULL(@RecipeIngredientId,0), @RecipeId = ISNULL(@RecipeId,0)

    select ri.RecipeIngredientId, ri.RecipeId, Quantity = ri.MeasurementAmount, Sequence = ri.IngredientSequence
    from RecipeIngredient ri 
    where ri.RecipeIngredientId = @RecipeIngredientId 
    or @All = 1 
    or ri.RecipeId = @RecipeId

    return @return 

end 
go 

exec RecipeIngredientGet @All = 1 