--AS This does not need to be it's own sproc, whatever you are trying to accomplish can go straight into the recipeget sproc
/*
CREATE OR ALTER PROCEDURE dbo.RecipeStatusGet(
    @RecipeId INT = NULL, 
    @RecipeName VARCHAR(100) = NULL, 
    @All BIT = 0
)
AS
BEGIN
    SET @RecipeName = NULLIF(@RecipeName, '')
 
    SELECT r.RecipeId, r.RecipeName, r.RecipeStatus, r.DateArchived, r.DateDrafted, r.DatePublished
    FROM Recipe r
    WHERE (@RecipeId IS NULL OR r.RecipeId = @RecipeId)
      AND (@RecipeName IS NULL OR r.RecipeName LIKE '%' + @RecipeName + '%')
      AND (@All = 1 OR r.RecipeId = @RecipeId OR r.RecipeName LIKE '%' + @RecipeName + '%')
    ORDER BY r.RecipeName
END
GO
/*


