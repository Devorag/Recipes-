create or alter proc dbo.DashboardGet(
    @Message varchar(500) = '' output
)
as 
begin 

    declare @return int = 0 

    select Type = 'Recipes', Number = count(distinct r.recipeID)
    from Recipe r 
    union select 'Meals', count(distinct m.mealID)
    from Meal m
    union select 'Cookbooks', count(distinct c.cookbookId)
    from Cookbook c  
    order by Type desc 

end
go 

exec DashboardGet