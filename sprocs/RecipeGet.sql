
create or alter procedure dbo.RecipeGet(
	@RecipeId int = 0, 
	@RecipeName varchar(100) = '',
	@All bit = 0,
	@IncludeBlank bit = 0
)
as 
begin 
	select @RecipeName = nullif(@RecipeName,''), @IncludeBlank = ISNULL(@IncludeBlank,0)

	select r.RecipeId, r.CuisineID, r.UsersId, r.RecipeName, r.Calories, r.Datedrafted, r.DatePublished, r.DateArchived, r.RecipeStatus, r.RecipePicture, IsDeleteAllowed = dbo.IsDeleteAllowed(r.RecipeId)
	from Recipe r
	where r.RecipeId = @RecipeId 
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
		union select 0,0,0,'',0,'','','','','',''
	where @IncludeBlank = 1 
	order by r.recipename, r.datedrafted, r.datepublished, r.datearchived, r.recipestatus, r.calories, r.recipepicture
end
go


exec RecipeGet @All = 1

declare @id int
select top 1 @id = r.recipeId from Recipe r 
exec RecipeGet @recipeId = @id