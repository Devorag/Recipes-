create or alter proc dbo.CookbookList
as 
begin 

    declare @return int = 0 
 
    ;
    with x as (
        select cr.cookbookId, NumRecipes = count(distinct cr.recipeID) 
        from recipe r 
        join CookbookRecipe cr 
        on cr.RecipeId = r.RecipeId 
        group by cr.CookbookId
    )
    
    select c.CookbookId, c.CookbookName, Author = u.UsersName, x.NumRecipes, c.Price 
    from x 
    join Cookbook c 
    on x.cookbookId = c.CookbookId 
    join users u 
    on u.UsersId = c.UsersId 

    return @return 

end 
go 




