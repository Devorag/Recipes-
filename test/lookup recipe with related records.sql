declare @recipeid int 

select @recipeid = r.recipeid from recipe r where r.RecipeName like '%Cheese%'
select 'recipe', r.recipeid, r.recipename from recipe r where r.recipeid = @recipeid 
union select 'recipe steps', rs.recipestepsid, rs.Instructions from RecipeSteps rs where rs.recipeid = @recipeid 
union select 'ingredients', i.ingredientid, i.IngredientName from ingredient i join RecipeIngredient ri on ri.RecipeIngredientId = i.IngredientId where ri.RecipeId = @recipeid  
