create or alter procedure dbo.CookbookGet (
    @CookbookId int = 0, 
    @CookbookName varchar(100) = '',
    @All bit = 0, 
	@IncludeBlank bit = 0
)
as 
begin 
    declare @return int = 0;

    if @All = 1
    begin
        ;with x as (
            SELECT c.CookbookId, c.CookbookName, NumRecipes = COUNT(cr.RecipeId)
            FROM Cookbook c
            LEFT JOIN CookbookRecipe cr ON c.CookbookId = cr.CookbookId
            GROUP BY c.CookbookId, c.CookbookName
        )
        select c.CookbookId, c.CookbookName, Author = u.UsersName, NumRecipes = ISNULL(x.NumRecipes, 0), c.Price, c.SkillLevelDescription
        from x 
        join Cookbook c 
		on x.CookbookId = c.CookbookId
        left join users u 
        on u.UsersId = c.UsersId 
        order by c.CookbookName;
    end
    else
    begin

        select @CookbookName = nullif(@CookbookName, '');

        ;with x as (
            SELECT c.CookbookId, c.CookbookName, NumRecipes = COUNT(cr.RecipeId)
            FROM Cookbook c
            LEFT JOIN CookbookRecipe cr ON c.CookbookId = cr.CookbookId
            GROUP BY c.CookbookId, c.CookbookName
        )
        select c.CookbookId, u.UsersId, c.CookbookName, c.Price, c.Active, c.DateCreated, c.CookbookPicture, c.SkillLevelDescription
        from Cookbook c 
        left join users u 
        on u.UsersId = c.UsersId
        where c.CookbookId = @CookbookId 
        or @CookbookName != '' and c.CookbookName like '%' + @CookbookName + '%'
        order by c.CookbookName;
    end

    return @return;
end
go

exec CookbookGet @All = 1