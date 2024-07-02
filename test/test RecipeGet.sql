
declare @id int 

select top 1 @id = r.recipeid from recipe r 

select @id 

exec RecipeGet @RecipeId = @id
 

--select @id
