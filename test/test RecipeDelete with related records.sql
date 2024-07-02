use RecipeDB
go 

declare @Recipeid int 

select top 1 @recipeid = r.recipeId 
from recipe r 
join recipesteps rs 
on rs.recipeid = r.recipeid 
join recipeingredient ri 
on ri.recipeid = r.recipeid 
join ingredient i 
on i.IngredientId = ri.IngredientId 
join MealCourseRecipe mcr 
on mcr.RecipeId = r.RecipeId 
join CookbookRecipe cr 
on cr.RecipeId = r.RecipeId 
order by r.recipeid 

select * from recipe r where r.recipeid = @recipeid

exec recipedelete @Recipeid = @RecipeId

select * from recipe r where r.recipeid = @recipeid