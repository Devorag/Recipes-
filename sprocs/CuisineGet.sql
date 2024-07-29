use RecipeDB 
go 

create or alter procedure dbo.CuisineGet(@CuisineId int = 0,  @CuisineName varchar(50) = '', @All bit = 0, @IncludeBlank bit = 0)
as 
begin 

	select @CuisineName = nullif(@CuisineName, ''), @IncludeBlank = isnull(@IncludeBlank, 0)

	select c.CuisineId, c.CuisineName
	from Cuisine c 
	where c.CuisineId = @CuisineId 
	or @All = 1
	or c.CuisineName like '%' + @CuisineName + '%'
	union select 0, ''
	where @IncludeBlank = 1 
	order by c.CuisineName
end
go

exec CuisineGet @All = 1

