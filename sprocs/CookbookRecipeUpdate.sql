create or alter procedure dbo.CookbookRecipeUpdate(
    @CookbookRecipeId int output,
    @CookbookId int ,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CookbookRecipeId = ISNULL(@CookbookRecipeId,0) 

    if @CookbookRecipeId = 0 
    begin 
        insert CookbookRecipe(CookbookId) 
        values (@CookbookId)

        select @CookbookRecipeId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update CookbookRecipe
        set 
            RecipeId = @CookbookId
        where CookbookRecipeId = @CookbookRecipeId 
    end

    return @return 

end 
go 