CREATE OR ALTER PROCEDURE dbo.RecipeGet
(
    @RecipeId INT = 0, 
    @RecipeName VARCHAR(100) = '',
    @CuisineName VARCHAR(100) = '',
    @All BIT = 0,
    @IncludeBlank BIT = 0
)
AS
BEGIN
    DECLARE @return INT = 0;

    SET @RecipeName = NULLIF(@RecipeName, '');
    SET @CuisineName = NULLIF(@CuisineName, '');
	select @RecipeId = isnull(@RecipeId,0)
	select @IncludeBlank = ISNULL(@IncludeBlank,0), @all = isnull(@all,0)
	
        SELECT 
            r.RecipeId, r.CuisineId, r.UsersId, r.RecipeName, r.Calories, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.RecipePicture, r.IsVegan, IsDeleteAllowed = dbo.IsDeleteAllowed(r.RecipeId)
		FROM Recipe r
        LEFT JOIN Cuisine c ON c.CuisineId = r.CuisineId
        WHERE 
            r.RecipeId = @RecipeId
            or (@RecipeName <> '' and r.RecipeName LIKE '%' + @RecipeName + '%')
			or (@CuisineName <> '' and c.CuisineName LIKE '%' + @CuisineName + '%')
            OR @IncludeBlank = 1 
			or @All = 1
        UNION ALL
        SELECT 0, 0, 0, '', 0, NULL, NULL, NULL, '', '', '', ''
        WHERE @IncludeBlank = 1

        ORDER BY r.RecipeName, r.DateDrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.Calories, r.RecipePicture;

        RETURN @return;

END;
GO
grant execute on RecipeGet to approle