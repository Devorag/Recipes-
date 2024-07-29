create or alter procedure dbo.CookbookRecipeDelete(
    @CookbookRecipeId int = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CookbookRecipeId = ISNULL(@CookbookRecipeId,0)

    delete CookbookRecipe where CookbookRecipeId = @CookbookRecipeId 

    return @return 

end 
go 

declare @id int 
select top 1 @id = CookbookRecipeId from CookbookRecipe
exec CookbookRecipeDelete @CookbookRecipeId = @id 