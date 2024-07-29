CREATE OR ALTER PROCEDURE dbo.UsersDelete(
    @UsersId INT = 0,
    @Message VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
    DECLARE @return INT = 0;
    BEGIN TRY
        BEGIN TRANSACTION;

   DELETE FROM CookbookRecipe WHERE CookbookId IN (SELECT CookbookId FROM Cookbook WHERE UsersId = @UsersId);
        DELETE FROM Cookbook WHERE UsersId = @UsersId;

        DELETE FROM MealCourseRecipe WHERE MealCourseId IN (SELECT MealCourseId FROM MealCourse WHERE MealId IN (SELECT MealId FROM Meal WHERE UsersId = @UsersId));
        DELETE FROM MealCourse WHERE MealId IN (SELECT MealId FROM Meal WHERE UsersId = @UsersId);
        DELETE FROM Meal WHERE UsersId = @UsersId;

        DELETE FROM RecipeSteps WHERE RecipeId IN (SELECT RecipeId FROM Recipe WHERE UsersId = @UsersId);
        DELETE FROM RecipeIngredient WHERE RecipeId IN (SELECT RecipeId FROM Recipe WHERE UsersId = @UsersId);
        DELETE FROM Recipe WHERE UsersId = @UsersId;

        -- Finally, delete the user
        DELETE FROM Users WHERE UsersId = @UsersId;

        -- Commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH;

    RETURN @return;
END;
GO
