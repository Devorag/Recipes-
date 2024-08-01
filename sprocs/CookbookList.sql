--AS Combine this sproc with cookbookget using if statement.
create or alter proc dbo.CookbookList
as 
begin 

    declare @return int = 0 
    ;
    with x as (
        SELECT 
            c.CookbookId,
            c.CookbookName, 
            NumRecipes = COUNT(cr.RecipeId)
        FROM 
            Cookbook c
        LEFT JOIN 
            CookbookRecipe cr ON c.CookbookId = cr.CookbookId
        GROUP BY 
            c.CookbookId,
            c.CookbookName
    )

    select c.CookbookId, c.CookbookName, Author = u.UsersName, NumRecipes = ISNULL(x.NumRecipes,0), c.Price
    from x 
    join Cookbook c 
    on x.cookbookName = c.CookbookName
    left join users u 
    on u.UsersId = c.UsersId 
    order by c.CookbookName 

    return @return 

end 
go 




