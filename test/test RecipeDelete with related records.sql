use RecipeDB
go 

declare @Recipeid int 

select top 1 @RecipeId = r.recipeid 
from recipe r 
join recipesteps rs 
on rs.recipeid = r.recipeid 
order by r.recipeid 

select * from recipe r where r.recipeid = @recipeid

exec recipedelete @Recipeid = @RecipeId

select * from recipe r where r.recipeid = @recipeid