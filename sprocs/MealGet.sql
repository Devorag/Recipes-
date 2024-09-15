create or alter proc dbo.MealGet(
    @MealId int = 0,
    @All bit = 0, 
	@IncludeBlank bit = 0,
    @Message varchar(500) = '' output
)
as 
begin 
 
    declare @return int = 0 
    
    select @All = ISNULL(@All,0), @MealId = ISNULL(@MealId, 0) 
    
    ;
    with x as (
        select mc.mealid, NumCourses = count(distinct mc.courseid), NumRecipes = count(r.recipeid)
        from MealCourse mc 
        left join MealCourseRecipe mcr 
        on mc.MealCourseId = mcr.MealCourseId
        left join recipe r 
        on r.RecipeId = mcr.RecipeId
        group by mc.MealId
    )
    
    select m.mealid, m.MealName, u.UsersName, NumCalories = dbo.TotalCaloriesPerMeal(m.MealId), x.NumCourses, x.NumRecipes
    from x 
    join meal m 
    on m.MealId = x.mealid
    join users u 
    on u.UsersId = m.usersid 
    order by m.MealName 
    
    return @return 

end 
go 

exec MealGet