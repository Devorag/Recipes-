CREATE OR ALTER PROCEDURE dbo.CookbookRecipeGet(
    @CookbookRecipeId INT = 0,
    @CookbookId INT = 0,
	@CookbookName varchar(100) = '',
    @All BIT = 0, 
    @IncludeBlank bit = 0,
    @Message VARCHAR(500) = '' OUTPUT
)
AS 
BEGIN 
    DECLARE @return INT = 0;

    SELECT @All = ISNULL(@All, 0), 
           @CookbookRecipeId = ISNULL(@CookbookRecipeId, 0), 
           @CookbookId = ISNULL(@CookbookId, 0)
    SELECT cr.CookbookRecipeId, cr.CookbookId, cr.RecipeId, cr.RecipeSequence, r.RecipeName, r.calories, c.CookbookName
    FROM CookbookRecipe cr 
    left join recipe r 
    on r.RecipeId = cr.RecipeId
	left join cookbook c 
	on c.cookbookId = cr.CookbookId
    WHERE (@All = 1) OR 
          (cr.CookbookRecipeId = @CookbookRecipeId) OR 
          (cr.CookbookId = @CookbookId) Or
		  c.CookbookName like '%' + @CookbookName + '%'
    ORDER BY cr.recipeSequence 

    RETURN @return;
END 
GO


exec CookbookRecipeGet @All = 1 