
create or alter procedure dbo.UsersGet(@UsersId int = 0, @UsersName varchar(100) = '', @All bit = 0, @IncludeBlank bit = 0)
as  
begin 

	select @UsersName = nullif(@UsersName, '') , @IncludeBlank = ISNULL(@IncludeBlank,0)

	select u.UsersId, u.FirstName, u.LastName, u.UsersName
	from Users u 
	where u.UsersId = @UsersId 
	or @All = 1
	or u.UsersName like '%' + @UsersName + '%'
	union select 0, '', '', ''
	where @IncludeBlank = 1 
	order by u.LastName, u.FirstName, u.UsersName
end
go

exec UsersGet @UsersName = '' 
exec UsersGet @UsersName = 'a'

exec UsersGet @All = 1

declare @id int 
select top 1 @id = u.UsersId from Users u 
exec UsersGet @UsersId = @id