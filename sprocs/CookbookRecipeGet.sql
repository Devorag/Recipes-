create or alter procedure dbo.CookbookRecipeGet(
    @CookbookRecipeId int = 0,
    @RecipeId int = 0,
    @All bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @All = isnull(@All,0), @CookbookRecipeId = ISNULL(@CookbookRecipeId,0), @RecipeId = ISNULL(@RecipeId,0)

    select cr.CookbookRecipeId, r.RecipeId, Sequence = cr.RecipeSequence
    from CookbookRecipe cr 
    left join recipe r 
    on r.RecipeId = cr.RecipeId
    where cr.CookbookRecipeId = @CookbookRecipeId
    or @All = 1 
    or cr.RecipeId = @RecipeId

    return @return 

end 
go 

exec RecipeIngredientGet @All = 1 