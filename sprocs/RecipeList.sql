--AS This should be combined with the regular RecipeGet sproc
--create or alter procedure dbo.RecipeList 
--as 
--begin 
--        declare @return int = 0

--        ;
--        with x as
--        ( 
--        select RecipeName, NumIngredients = count(ri.IngredientId) 
--        from recipe r 
--        left join RecipeIngredient ri 
--        on ri.RecipeId = r.RecipeId
--        group by r.RecipeName
--        )

--        select r.RecipeId, r.RecipeName, Status = r.recipestatus, u.UsersName, r.Calories, x.NumIngredients
--        from x 
--        join recipe r 
--        on r.RecipeName = x.RecipeName 
--        left join users u 
--        on u.usersid = r.usersid 
--        order by r.RecipeStatus desc 
         
--        return @return
--end 
--go

--exec RecipeList