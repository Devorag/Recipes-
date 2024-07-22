CREATE OR ALTER PROCEDURE dbo.CreateCookbook
(
    @UsersId INT = 0,
    @CookbookId INT = 0 OUTPUT
)
AS
BEGIN
    DECLARE @CookbookName VARCHAR(150)
    
    SELECT @CookbookName = CONCAT('Recipes by ', u.FirstName, ' ', u.LastName)
    FROM users u
    where u.UsersId = @UsersId
    order by u.UsersName desc

    --IF EXISTS (SELECT 1 FROM Cookbook WHERE CookbookName = @CookbookName)
    --BEGIN
       -- RAISERROR('Cookbook name already exists.', 16, 1);
      --  RETURN;
    --END

    -- Insert new cookbook
    INSERT Cookbook (UsersId, CookbookName, Price, Active)
    SELECT u.UsersId, @CookbookName, COUNT(r.RecipeId) * 1.33, 1
    FROM users u
    JOIN recipe r 
    ON r.UsersId = u.UsersId
    WHERE u.UsersId = @UsersId
    GROUP BY u.UsersId, u.FirstName, u.LastName;

    -- Get the newly created CookbookId
    SELECT @CookbookId = SCOPE_IDENTITY();

    WITH x AS (
        SELECT 
            CookbookName = CONCAT('Recipes by ', u.FirstName, ' ', u.LastName),
            RecipeSequence = ROW_NUMBER() OVER (ORDER BY r.RecipeName),
            r.RecipeName
        FROM users u
        JOIN recipe r 
        ON r.UsersId = u.UsersId
        join Cookbook c
        ON c.UsersId = u.UsersId
        WHERE u.UsersId = @UsersId
    )
    INSERT INTO CookbookRecipe (CookbookID, RecipeId, RecipeSequence)
    SELECT 
        c.CookbookId, 
        r.RecipeId, 
        x.RecipeSequence 
    FROM x
    JOIN recipe r 
    ON r.RecipeName = x.RecipeName
    join Cookbook c 
    on c.CookbookName = x.CookbookName
    WHERE x.CookbookName like '%Recipes by %'
END;
GO


declare @id int 
select @id = u.UsersId from Users u 
exec CreateCookbook @UsersId = @id