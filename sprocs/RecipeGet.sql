
create or alter procedure dbo.RecipeGet(
	@RecipeId int = 0, 
	@RecipeName varchar(100) = '',
	@All bit = 0,
	@IncludeBlank bit = 0
)
as 
begin 
	declare @return int = 0; 

	if @All = 1 and @IncludeBlank = 0
	begin 

	    ;
        with x as
        ( 
        select r.RecipeId, r.RecipeName, NumIngredients = count(ri.IngredientId) 
        from recipe r 
        left join RecipeIngredient ri 
        on ri.RecipeId = r.RecipeId
        group by r.RecipeName, r.recipeId
        )

        select r.RecipeId, r.RecipeName, Status = r.recipestatus, u.UsersName, r.Calories, x.NumIngredients
        from x 
        join recipe r 
        on r.RecipeId = x.RecipeId
        left join users u 
        on u.usersid = r.usersid 
        order by r.RecipeStatus desc 
         
        return @return
	end 
	else
	begin

	select @RecipeName = nullif(@RecipeName,''), @IncludeBlank  = ISNULL(@IncludeBlank,0)
	
	select r.RecipeId, r.CuisineID, r.UsersId, r.RecipeName, r.Calories, r.Datedrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.RecipePicture, IsDeleteAllowed = dbo.IsDeleteAllowed(r.RecipeId)
	from Recipe r
	where r.RecipeId = @RecipeId 
	or r.RecipeName like '%' + @RecipeName + '%'
	or @IncludeBlank = 1
	union select 0,0,0,'',0,'','','','','',''
	where @IncludeBlank = 1 
	order by r.recipename, r.datedrafted, r.datepublished, r.datearchived, r.recipestatus, r.calories, r.recipepicture
end
	return @return
end
go

