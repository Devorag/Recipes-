create or alter procedure dbo.CookbokoRecipeUpdate(
    @CookbookRecipeId int output,
    @RecipeId int ,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CookbookRecipeId = ISNULL(@CookbookRecipeId,0) 

    if @CookbookRecipeId = 0 
    begin 
        insert CookbookRecipe(RecipeId) 
        values (@RecipeId)

        select @CookbookRecipeId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update CookbookRecipe
        set 
            RecipeId = @RecipeId
        where CookbookRecipeId = @CookbookRecipeId 
    end

    return @return 

end 
go 