declare @recipeid int 

select @recipeid = r.recipeid from recipe r where r.Calories > 475
select 'recipe', r.recipeid, r.recipename from recipe r where r.recipeid = @recipeid 
union select 'recipe steps', rs.recipestepsid, rs.Instructions from RecipeSteps rs where rs.recipeid = @recipeid 
union select 'recipe ingredients',  ri.recipeingredientid, ri.IngredientSequence from RecipeIngredient ri where ri.recipeid = @recipeid