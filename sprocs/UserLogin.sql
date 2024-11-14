create or alter procedure dbo.UserLogin(
	@username varchar(20), 
	@password varchar(20), 
	@message varchar(500) = '' output
)
as 
begin 
	declare @return int = 0, @userid int
	select @message = ''

	select @userid = u.userid from users2 u where u.username = @username and u.password = @password

	if isnull(@userid,0) > 0
	begin 
		update users2
		set sessionkey=newid(), sessionkeyDate = getdate()
		where userId = @userId

		select u.userid, u.roleid, u.username, u.sessionkey, r.rolename, r.rolerank
		from users2 u 
		join roles r 
		on r.roleid = u.roleid
		where u.userid = @userid 

	end
	else 
	begin 
		select @return = 1, @message = 'invalid login'
	end

	return @return 
end
go
grant execute on UserLogin to approle