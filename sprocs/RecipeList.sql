create or alter procedure dbo.RecipeList 
as 
begin 
        declare @return int = 0

        ;
        with x as
        ( 
        select RecipeName, NumIngredients = count(ri.IngredientId) 
        from recipe r 
        left join RecipeIngredient ri 
        on ri.RecipeId = r.RecipeId
        group by r.RecipeName
        )

        select r.RecipeId, r.RecipeName, Status = r.recipestatus, u.UsersName, r.Calories, x.NumIngredients
        from x 
        join recipe r 
        on r.RecipeName = x.RecipeName 
        left join users u 
        on u.usersid = r.usersid 
        order by r.datepublished, r.datedrafted, r.datearchived
        
        return @return
end 
go

exec RecipeSearch 