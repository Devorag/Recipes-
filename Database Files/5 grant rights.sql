use RecipeDb
go 
--select concat('grant execute on ', r.ROUTINE_NAME, ' to approle') 
--from INFORMATION_SCHEMA.ROUTINES r

grant execute on Users2Get to approle
grant execute on UserLogin to approle
grant execute on UserLogout to approle
grant execute on ChangeRecipeStatus to approle
grant execute on CookbookUpdate to approle
grant execute on CookbookDelete to approle
grant execute on CookbookGet to approle
grant execute on CookbookRecipeDelete to approle
grant execute on CookbookRecipeGet to approle
grant execute on CookbookRecipeUpdate to approle
grant execute on CourseDelete to approle
grant execute on CourseGet to approle
grant execute on CreateCookbook to approle
grant execute on CourseUpdate to approle
grant execute on CuisineDelete to approle
grant execute on CuisineGet to approle
grant execute on DashboardGet to approle
grant execute on CuisineUpdate to approle
grant execute on IngredientDelete to approle
grant execute on IngredientGet to approle
grant execute on IngredientUpdate to approle
grant execute on MealGet to approle
grant execute on TotalCaloriesPerMeal to approle
grant execute on MeasurementDelete to approle
grant execute on MeasurementUpdate to approle
grant execute on MeasurementGet to approle
grant execute on CloneRecipe to approle
grant execute on RecipeDelete to approle
grant execute on RecipeGet to approle
grant execute on RecipeIngredientDelete to approle
grant execute on RecipeIngredientGet to approle
grant execute on RecipeIngredientUpdate to approle
grant execute on RecipeUpdate to approle
grant execute on RecipeStepsDelete to approle
grant execute on RecipeStepsGet to approle
grant execute on RecipeStepsUpdate to approle
grant execute on StepsGet to approle
grant execute on UsersDelete to approle
grant execute on UsersGet to approle
grant execute on UsersUpdate to approle