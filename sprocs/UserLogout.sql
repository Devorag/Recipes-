create or alter procedure dbo.UserLogout(
	@username varchar(20), 
	@message varchar(500) = '' output
)
as 
begin 
	declare @return int = 0, @userid int
	select @message = ''

	update users2 set 
	sessionkey = '', 
	sessionkeydate = null 
	where username = @username

	return @return 
end
go
grant execute on UserLogout to approle