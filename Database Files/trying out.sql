--CREATE OR ALTER PROCEDURE dbo.RecipeGet
declare
    @RecipeId INT = 0, 
    @RecipeName VARCHAR(100) = '',
    @CuisineName VARCHAR(100) = '',
    @All BIT = 0,
    @IncludeBlank BIT = 0

	select @RecipeId = null ,  
@RecipeName = null ,  
@CuisineName = 'american' ,  
@All = 1 ,  
@IncludeBlank = 0  

BEGIN
    DECLARE @return INT = 0;

    SET @RecipeName = NULLIF(@RecipeName, '');
    SET @CuisineName = NULLIF(@CuisineName, '');
	select @RecipeId = isnull(@RecipeId,0)

    IF @All = 1 AND isnull(@IncludeBlank,0) = 0
    BEGIN
        WITH RecipeSummary AS (
            SELECT 
                r.RecipeId, 
                r.RecipeName, 
                COUNT(ri.IngredientId) AS NumIngredients
            FROM Recipe r
            LEFT JOIN RecipeIngredient ri ON ri.RecipeId = r.RecipeId
            GROUP BY r.RecipeId, r.RecipeName
        )
        SELECT 
            r.RecipeId, r.RecipeName, r.RecipeStatus, r.DateDrafted, r.DateArchived, r.DatePublished, u.UsersName, r.Calories, rs.NumIngredients, r.RecipePicture, r.IsVegan, c.CuisineName
        FROM Recipe r
        JOIN RecipeSummary rs ON r.RecipeId = rs.RecipeId
        LEFT JOIN Users u ON u.UsersId = r.UsersId
        LEFT JOIN Cuisine c ON c.CuisineId = r.CuisineId
        WHERE (@RecipeId = 0 OR r.RecipeId = @RecipeId)
          AND (@CuisineName IS NULL OR c.CuisineName LIKE '%' + @CuisineName + '%')
        ORDER BY r.RecipeStatus DESC;

        
    END
    ELSE
    BEGIN
        SELECT 
            r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.RecipePicture, r.IsVegan, IsDeleteAllowed = dbo.IsDeleteAllowed(r.RecipeId)
        FROM Recipe r
        LEFT JOIN Cuisine c ON c.CuisineId = r.CuisineId
        WHERE 
            (@RecipeId = 0 OR r.RecipeId = @RecipeId)
            AND (@RecipeName IS NULL OR r.RecipeName LIKE '%' + @RecipeName + '%')
            AND (@CuisineName IS NULL OR c.CuisineName LIKE '%' + @CuisineName + '%')
            OR @IncludeBlank = 1 
        UNION ALL
        SELECT 0, 0, 0, '', 0, NULL, NULL, NULL, '', '', '', ''
        WHERE @IncludeBlank = 1

        ORDER BY r.RecipeName, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.Calories, r.RecipePicture;

        
    END
END;
GO
