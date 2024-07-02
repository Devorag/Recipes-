use RecipeDB 
go 

set nocount on 

declare @recipeid int 

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

select 'recipe', r.recipeid, r.recipename from recipe r where r.recipeid = @recipeid 
union select 'recipe steps', rs.recipestepsid, rs.Instructions from RecipeSteps rs where rs.recipeid = @recipeid 
union select 'ingredients', i.ingredientid, i.IngredientName from ingredient i join RecipeIngredient ri on ri.RecipeIngredientId = i.IngredientId where ri.RecipeId = @recipeid  

exec RecipeDelete @Recipeid = @recipeid 

select 'recipe', r.recipeid, concat(r.recipename, ' ', r.recipestatus) from recipe r where r.recipeid = @recipeid 
union select 'recipe steps', rs.recipestepsid, rs.Instructions from RecipeSteps rs where rs.recipeid = @recipeid 
union select 'ingredients', i.ingredientid, i.IngredientName from ingredient i 
    join RecipeIngredient ri on ri.RecipeIngredientId = i.IngredientId where ri.RecipeId = @recipeid  