-- SM Excellent work! 100% See comments, no need to resubmit. 

/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
;
select ItemName = 'Recipes', Total = count(recipeId) from recipe r 
union select ItemName = 'Meals', Total =  count(mealId) from meal m 
union select ItemName = 'Cookbooks', Total = count(c.cookbookId) from Cookbook c 



/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
select 
    RecipeName = case 
    when r.RecipeStatus = 'archived' then concat('<span style="color:gray">', r.recipename, '</span>') 
    else r.recipename end, 
    DatePublished = isnull(convert(varchar,r.DatePublished,101), ''),
    DateArchived = isnull(convert(varchar, r.datearchived, 101), ''), 
    r.RecipeStatus, r.calories, 
    NumIngredients = count(distinct ri.ingredientId)
from recipe r
join Users u 
on u.UsersId = r.UsersId 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId 
where r.DatePublished is not null
or r.datearchived is not null 
group by r.RecipeName, r.DatePublished, r.DateArchived, r.RecipeStatus, r.Calories
order by DateArchived, r.DatePublished



/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories, NumIngredients = count(distinct ri.ingredientID), NumSteps = count(distinct rs.instructions)
from recipe r 
join recipeIngredient ri 
on r.recipeID = ri.recipeID 
join recipesteps rs 
on rs.RecipeId = r.RecipeId 
where r.RecipeName = 'Sesame Chicken'
group by r.RecipeName, r.Calories

-- SM You have the same issue here as you had in data file.
select IngredientList = concat(ri.MeasurementAmount, ' ' , um.MeasurementType, ' ', i.IngredientName)
from ingredient i 
join RecipeIngredient ri 
on ri.IngredientId = i.IngredientId
join recipe r 
on r.RecipeId = ri.RecipeId 
join UnitOfMeasure um 
on um.UnitOfMeasureId = ri.UnitOfMeasureId 
where r.recipeName= 'Sesame Chicken' 
order by ri.IngredientSequence 

select rs.Instructions
from RecipeSteps rs 
join recipe r 
on r.recipeId = rs.RecipeId 
where r.RecipeName = 'Sesame Chicken'
order by rs.stepSequence


/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, u.Username, TotalCalories = sum(r.calories), NumCourses = count(distinct c.courseID), NumRecipes = count(distinct r.recipeId)
from meal m 
join users u 
on u.usersId = m.UsersId 
join Mealcourse mc 
on mc.mealID = m.mealID  
join MealCourseRecipe mcr
on mcr.mealcourseID = mc.MealCourseId  
join recipe r 
on r.recipeID = mcr.recipeId  
join course c 
on c.CourseId = mc.CourseId 
where m.Active = '1'
group by m.mealname, u.UserName
order by m.mealname
/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select m.mealname, u.username, m.DateCreated
from meal m 
join users u 
on u.UsersId = m.UsersId 
where m.MealName = 'Supper Crunch'

select RecipeList = case when c.coursetype = 'main course' and mcr.maindish = 1 then concat('<b>', c.CourseType, ': ', 'Main Dish', ' - ', r.recipename, '</b>') 
when c.coursetype = 'main course' and mcr.maindish = 0 then concat(c.Coursetype, ': ', 'Side Dish' , ' - ', r.RecipeName) 
else concat(c.CourseType, ': ', r.RecipeName) end
from course c 
join MealCourse mc 
on mc.CourseId = c.CourseId 
join meal m 
on m.mealId = mc.MealId 
join MealCourseRecipe mcr 
on mcr.mealcourseID = mc.MealCourseId 
join recipe r 
on r.RecipeId = mcr.recipeID  
where m.mealname = 'Supper Crunch'

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, u.username, NumRecipes = count(distinct r.recipeID)
from cookbook c 
join users u 
on u.UsersId = c.UsersId 
join CookbookRecipe cr 
on cr.CookbookId = c.CookbookId 
join recipe r 
on r.RecipeId = cr.RecipeId 
where c.Active = 1
group by c.CookbookName, u.UserName
order by c.CookbookName 

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
Select c.CookbookName, u.username, c.DateCreated, c.price, NumRecipes = count(distinct r.recipeId)
from cookbook c 
join users u 
on u.UsersId = c.usersID 
join CookbookRecipe cr 
on cr.CookbookId = c.cookbookId 
join recipe r 
on r.RecipeId = cr.RecipeId 
where c.CookbookName = 'Taste It'
group by c.CookbookName, u.username, c.DateCreated, c.Price

select r.RecipeName, cu.cuisineType, NumIngredients = count( distinct i.ingredientId), NumSteps = count( distinct rs.instructions), cr.RecipeSequence
from Ingredient i 
join RecipeIngredient ri
on ri.ingredientID = i.IngredientId
join Recipesteps rs 
on rs.recipeId = ri.RecipeId 
join recipe r 
on r.RecipeId = rs.RecipeId
join cuisine cu 
on cu.CuisineId = r.CuisineID
join cookbookrecipe cr 
on cr.recipeID = r.RecipeId
join cookbook c 
on c.CookbookId = cr.CookbookId 
where c.CookbookName = 'Taste It'
group by r.RecipeName, cu.CuisineType, cr.RecipeSequence 
order by cr.recipesequence 

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
select distinct RecipeName = concat(upper(substring(reverse(r.RecipeName),1,1)), lower(SUBSTRING(reverse(r.RecipeName),2,20))), RecipePicture = concat('Recipe', '_', replace(reverse(RecipeName), ' ', '_'), '.jpg') 
from recipe r 
join CookbookRecipe cr 
on cr.recipeID = r.recipeID 
join cookbook c 
on c.CookbookId = cr.cookbookId 

;
with x as(
    select r.recipeName, LastStep = max(rs.stepsequence)
    from recipe r 
    join RecipeSteps rs 
    on rs.RecipeId = r.RecipeId
    group by r.RecipeName
)
select rs.instructions
from x 
join recipe r 
on r.RecipeName = x.RecipeName  
join RecipeSteps rs 
on rs.RecipeId = r.RecipeId 
where rs.StepSequence = x.LastStep 


/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
select u.username, RecipeStatus = isnull(r.recipestatus, ' '), TotalRecipesCreated = count(distinct r.RecipeId)
from users u 
left join recipe r 
on r.UsersId  = u.UsersId 
group by r.RecipeStatus, u.UserName

select u.username, TotalRecipesCreated = count(distinct r.RecipeId), AvgTimeToBePublished = avg(DATEDIFF(day, r.datedrafted, r.DatePublished))
from users u 
left join recipe r 
on r.UsersId  = u.UsersId 
where r.datepublished is not null 
group by u.username

select u.userName, TotalNumMeals = count(m.mealId), TotalActiveMeals = sum(case when m.active = 1 then 1 else 0 end), TotalInactiveMeals = sum(case when m.active = 0 then 1 else 0 end)
from users u 
join meal m 
on m.UsersId = u.UsersID 
group by u.UserName

select u.userName, TotalNumCookbooks = count(distinct c.cookbookId), TotalActiveCookbooks = sum(case when c.active = 1 then 1 else 0 end), TotalInactiveCookbooks = sum(case when c.active = 0 then 1 else 0 end)
from users u 
join cookbook c 
on c.usersId = u.usersId
group by u.UserName

select r.recipeName, TimeToBeArchived = datediff(day, r.DateDrafted, r.datearchived)
from recipe r 
where r.DatePublished is null 
and r.DateArchived is not null 
/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
     */
     
select ItemName = 'Recipes', Total = count(r.recipeId) 
from recipe r 
join users u 
on r.UsersId = u.UsersId 
where u.username = 'Msvei'
union select 'Meals', count(m.mealId) 
from meal m 
join users u 
on m.usersId = u.usersId 
where u.username = 'Msvei'
union select 'Cookbooks', count(c.cookbookId) 
from Cookbook c 
join users u 
on c.UsersId = u.usersId 
where u.UserName = 'Msvei'

-- SM Tip: Use one datediff() with multiple case statements in it, like that you'll be able to do isnull()
select u.UserName, r.RecipeName, r.RecipeStatus, NumHoursbetweenstatuses = case when r.recipestatus = 'Published' then DATEDIFF(hour, r.datedrafted, r.DatePublished) 
when r.recipestatus = 'Archived' and r.DatePublished is not null then DATEDIFF(hour, r.DatePublished, r.DateArchived)
when r.recipeStatus = 'Archived' and r.datepublished is null then datediff(hour, r.datedrafted, r.datearchived) 
end 
from recipe r 
join users u 
on u.UsersId = r.UsersId 
where r.RecipeStatus in ('Published', 'Archived')
and u.userName = 'Msvei'

/*
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
