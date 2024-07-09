use RecipeDB 
go 

declare @RecipeId int 

select top 1 @RecipeId = r.recipeid 
from recipe r 
left join RecipeSteps rs 
on rs.recipeid = r.recipeid 
left join RecipeIngredient ri 
on ri.recipeid = r.recipeid
where rs.recipestepsid is null 
and ri.recipeingredientid is null 
order by r.recipeid 

exec RecipeDelete 
