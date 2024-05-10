-- SM Excellent work! 100%
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.

--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete Ri 
from recipeIngredient ri
join recipe r 
on r.RecipeId = ri.recipeId 
join users u 
on u.UsersId = r.UsersId 
where u.UserName = 'Dmozes'

delete rs 
from RecipeSteps rs 
join recipe r 
on r.RecipeId = rs.RecipeId 
join users u 
on u.UsersId = r.UsersId 
where u.UserName = 'Dmozes'

delete mcr 
from mealcourserecipe mcr 
join recipe r 
on r.recipeId = mcr.recipeId
join users u 
on u.UsersId = r.UsersId  
where u.userName = 'Dmozes'

delete cr 
from CookbookRecipe cr 
join recipe r 
on r.recipeId = cr.recipeId 
join users u 
on u.UsersId = r.usersId 
where u.userName = 'Dmozes'

delete r 
from recipe r 
join users u 
on u.usersID = r.usersId 
where u.username = 'Dmozes'


delete mcr 
from MealCourseRecipe mcr 
join mealcourse mc 
on mc.mealCourseId = mcr.mealcourseID 
join meal m 
on m.mealId = mc.mealId  
join users u 
on u.UsersId = m.UsersId 
where u.UserName = 'Dmozes'


delete mc 
from MealCourse mc 
join meal m 
on m.MealId = mc.MealId 
join users u 
on u.usersID = m.UsersId 
where u.UserName = 'Dmozes'

delete m 
from meal m 
join users u  
on u.usersID = m.usersId 
where u.username = 'Dmozes'  

delete c 
from cookbook c 
join users u 
on u.usersID = c.usersID 
where u.username = 'Dmozes'

delete u 
from users u 
where u.username = 'Dmozes'
--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.

insert Recipe(CuisineID, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select r.cuisineId, r.usersId, concat(r.recipeName, ' - clone'), r.calories, getdate(), getdate(), null 
from recipe r 
where r.RecipeName = 'Ministroni Soup'
;
with x as(
	select r.recipeID, r.recipeName 
	from recipe r 
	where r.RecipeName ='Ministroni Soup - clone'
)
Insert RecipeIngredient(RecipeId, IngredientId, UnitOfMeasureID, MeasurementAmount, IngredientSequence)
select x.recipeId, ri.ingredientId, ri.unitOfMeasureId, ri.measurementAmount, ri.IngredientSequence
from x 
cross join Recipe r 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId 
where r.RecipeName = 'Ministroni Soup'
;
with x as(
	select r.recipeId, r.recipeName
	from recipe r 
	where r.RecipeName = 'Ministroni soup - clone'
)
insert RecipeSteps(RecipeId, Instructions, StepSequence)
select x.recipeId, rs.instructions, rs.StepSequence 
from x 
cross join recipe r 
join RecipeSteps rs 
on rs.RecipeId = r.RecipeId 
where r.RecipeName = 'Ministroni soup'

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
insert cookbook(UsersId, CookbookName, Price)
select u.usersId, concat('Recipes by ', u.FirstName, ' ', u.LastName), count(r.RecipeId) * 1.33
from users u 
join recipe r
on r.UsersId = u.UsersId 
where u.LastName = 'Mozes'
group by u.usersId, u.firstName, u.LastName

;
with x as(
	select CookbookName = concat('Recipes by ', u.FirstName, ' ', u.LastName), RecipeSequence = ROW_NUMBER() over (order by r.recipeName) , r.recipeName
	from Cookbook c 
	join  users u 
	on u.usersId = c.usersId 
	join Recipe r 
	on r.UsersId = u.UsersId 
)
insert CookbookRecipe(CookbookID, RecipeId, RecipeSequence)
select c.cookbookId, r.RecipeId, x.recipeSequence 
from x 
join Cookbook c 
on c.cookbookName = x.cookbookName 
join recipe r 
on r.recipeName = x.recipeName 
where c.CookbookName = 'Recipes by Devorah Mozes'

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
;
with x as(
	select Calories = case when um.MeasurementType = 'oz' then r.calories -(2 * ri.measurementAmount) 
	when um.MeasurementType = 'stick' then r.calories - (10 * ri.measurementAmount) 
	else r.calories
	end
	from UnitOfMeasure um 
	join RecipeIngredient ri 
	on ri.UnitOfMeasureID = um.UnitOfMeasureID
	join recipe r 
	on r.RecipeId = ri.recipeId 
)
update r 
set r.Calories = x.calories 
from x 
join recipe r 
on r.Calories = x.calories 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId 
join ingredient i 
on i.IngredientId = ri.IngredientId 
where i.IngredientName = 'butter'
/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;
with x as(
	select AvgHoursInDraft = avg(DATEDIFF(hour, r.datedrafted, r.datepublished))
	from recipe r
)
select u.firstname, u.lastname, 
EmailAdress = concat(substring(u.firstname, 1, 1), u.lastname, '@heartyhearth.com'), 
Alert = concat('Your recipe ', r.recipeName, ' is sitting in draft for ', DATEDIFF(hour, r.datedrafted, getdate()), ' hours. 
		That is ', datediff(hour, r.datedrafted, getdate()) - x.avgHoursInDraft, ' hours more than the average ', x.avgHoursInDraft, ' hours all other recipes took to be published.')
from x 
cross join recipe r 
join users u 
on u.usersId = r.usersId 
where r.RecipeStatus = 'Drafted'
and datediff(hour, r.DateDrafted, GETDATE()) > x.AvgHoursInDraft
/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select EmailBody = concat( 'Order cookbooks from HeartyHearth.com! We have ',count(c.cookbookId),' books for sale, average price is ',avg(c.price),' You can order them all and receive a 25% discount, for a total of ', sum(c.price) - .25 * sum(c.price), ' Click <a href = "www.heartyhearth.com/order/', newId(), '">here</a> to order.')
from cookbook c 




