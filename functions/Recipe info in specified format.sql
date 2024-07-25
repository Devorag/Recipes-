create or alter function dbo.RecipeInfoInSpecifiedFormat(@RecipeId int) 
returns varchar(75)
as 
begin 
    declare @value varchar (75) = '' 

    select @value = concat(
        r.RecipeName, ' (', c.CuisineName, ') has ',
        (select count(*) from RecipeIngredient ri where ri.RecipeId = r.RecipeId), ' ingredients and ',
        (select count(*) from RecipeSteps rs where rs.RecipeId = r.RecipeId), ' steps.'
    )
    from recipe r 
    left join Cuisine c 
    on c.CuisineId = r.CuisineID
    where r.RecipeId = @recipeid 

    return @value
end 
go 

select RecipeSpecifiedFormat = dbo.RecipeInfoInSpecifiedFormat(r.recipeid)
from recipe r 