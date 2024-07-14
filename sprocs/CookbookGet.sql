create or alter proc dbo.CookbookGet(
    @CookbookId int = 0,
    @All bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 

    declare @return int = 0 
    
    select @All = ISNULL(@All,0), @CookbookId = ISNULL(@CookbookId,0)
    
    ;
    with x as (
        select cr.cookbookId, NumRecipes = count(distinct cr.recipeID) 
        from recipe r 
        join CookbookRecipe cr 
        on cr.RecipeId = r.RecipeId 
        group by cr.CookbookId
    )
    
    select c.CookbookName, Author = u.UserName, x.NumRecipes, c.Price 
    from x 
    join Cookbook c 
    on x.cookbookId = c.CookbookId 
    join users u 
    on u.UsersId = c.UsersId 
    order by c.CookbookName
    
    return @return 

end 
go 