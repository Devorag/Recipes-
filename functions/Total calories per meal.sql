create or alter function dbo.TotalCaloriesPerMeal(@MealId int) 
returns int 
as 
begin 
    declare @value int = 0
  select @value = sum(r.Calories)
from recipe r 
left join mealcourserecipe mcr
on mcr.recipeid = r.recipeid 
left join MealCourse mc
on mc.MealCourseId = mcr.MealCourseId
left join meal m 
on m.mealid = mc.mealid 
where m.mealid = @mealid 
group by m.MealName

return @value 

end
go 

Select TotalCaloriesPerMeal = dbo.TotalCaloriesPerMeal(m.mealid), *
from meal m 