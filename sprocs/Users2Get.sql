create or alter procedure dbo.Users2Get(
	@userId int, 
	@sessionkey varchar(255), 
	@message varchar(500) = '' output
)
as 
begin 
	declare @return int = 0 
			select u.userid, u.roleid, u.username, u.sessionkey, r.rolename, r.rolerank
		from users2 u 
		join roles r 
		on r.roleid = u.roleid
		where u.userid = @userid 
		or (u.sessionkey = @sessionkey and @sessionkey != '')

	return @return 
end
go 
grant execute on Users2Get to approle