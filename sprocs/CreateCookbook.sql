CREATE OR ALTER PROCEDURE dbo.CreateCookbook
(
    @UsersId INT = 0,
    @CookbookId INT = 0 OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CookbookName VARCHAR(150);

    -- Generate the cookbook name
    SELECT @CookbookName = CONCAT('Recipes by ', u.FirstName, ' ', u.LastName)
    FROM users u
    WHERE u.UsersId = @UsersId;

    INSERT INTO Cookbook (UsersId, CookbookName, Price, Active)
    SELECT u.UsersId, @CookbookName, COUNT(r.RecipeId) * 1.33, 1
    FROM users u
    JOIN recipe r 
    ON r.UsersId = u.UsersId
    WHERE u.UsersId = @UsersId
    GROUP BY u.UsersId, u.FirstName, u.LastName;

   
    SELECT @CookbookId = SCOPE_IDENTITY();

    
    WITH x AS (
        SELECT 
            CookbookName = CONCAT('Recipes by ', u.FirstName, ' ', u.LastName),
            RecipeSequence = ROW_NUMBER() OVER (ORDER BY r.RecipeName),
            r.RecipeName,
            r.RecipeId
        FROM users u
        JOIN recipe r ON r.UsersId = u.UsersId
        WHERE u.UsersId = @UsersId
    )
    INSERT INTO CookbookRecipe (CookbookID, RecipeId, RecipeSequence)
    SELECT 
        @CookbookId, 
        x.RecipeId, 
        x.RecipeSequence 
    FROM x
    JOIN Cookbook c 
    ON c.CookbookName = x.CookbookName
    WHERE c.CookbookId = @CookbookId;
    
END;
GO

declare @UsersId int 
select @UsersId = u.UsersId from users u
exec CreateCookbook @UsersId = @UsersId

