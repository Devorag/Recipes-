CREATE OR ALTER PROCEDURE dbo.UsersDelete(
    @UsersId INT = 0,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @return INT = 0;
    BEGIN TRY
        BEGIN TRANSACTION;

	delete Ri 
	from recipeIngredient ri
	join recipe r 
	on r.RecipeId = ri.recipeId 
	join users u 
	on u.UsersId = r.UsersId 
	where u.UsersId = @UsersId

	delete rs 
	from RecipeSteps rs 
	join recipe r 
	on r.RecipeId = rs.RecipeId 
	join users u 
	on u.UsersId = r.UsersId 
	where u.UsersId = @UsersId


	delete mcr 
	from mealcourserecipe mcr 
	join recipe r 
	on r.recipeId = mcr.recipeId
	join users u 
	on u.UsersId = r.UsersId  
	where u.UsersId = @UsersId


	delete cr 
	from CookbookRecipe cr 
	join recipe r 
	on r.recipeId = cr.recipeId 
	join users u 
	on u.UsersId = r.usersId 
	where u.UsersId = @UsersId


	delete r 
	from recipe r 
	join users u 
	on u.usersID = r.usersId 
	where u.UsersId = @UsersId



	delete mcr 
	from MealCourseRecipe mcr 
	join mealcourse mc 
	on mc.mealCourseId = mcr.mealcourseID 
	join meal m 
	on m.mealId = mc.mealId  
	join users u 
	on u.UsersId = m.UsersId 
	where u.UsersId = @UsersId



	delete mc 
	from MealCourse mc 
	join meal m 
	on m.MealId = mc.MealId 
	join users u 
	on u.usersID = m.UsersId 
	where u.UsersId = @UsersId


	delete m 
	from meal m 
	join users u  
	on u.usersID = m.usersId 
	where u.UsersId = @UsersId
  

	delete c 
	from cookbook c 
	join users u 
	on u.usersID = c.usersID 
	where u.UsersId = @UsersId


	delete u 
	from users u 
	where u.UsersId = @UsersId


        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH;

    RETURN @return;
END;
GO
