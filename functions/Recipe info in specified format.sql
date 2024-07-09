create or alter function dbo.RecipeInfoInSpecifiedFormat(@RecipeId int) 
returns varchar(75)
as 
begin 
    declare @value varchar (75) = '' 
    select @value = concat(r.RecipeName, ' (', c.cuisinetype, ') has ', count(distinct ri.IngredientId), ' ingredients and ', count(distinct rs.RecipeStepsId), ' steps.')
    from recipe r 
    left join Cuisine c 
    on c.CuisineId = r.CuisineID
    left join RecipeIngredient ri 
    on ri.RecipeId = r.RecipeId 
    left join RecipeSteps rs 
    on rs.RecipeId = r.RecipeId
    where r.RecipeId = @recipeid 
    group by r.RecipeName, c.CuisineType

    return @value
end 
go 

select RecipeSpecifiedFormat = dbo.RecipeInfoInSpecifiedFormat(r.recipeid), *
from recipe r 