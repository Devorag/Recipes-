select userid, sessionkey from users2

declare @message varchar(500), @return int, @sessionkey varchar(255)
select @sessionkey = sessionkey from users2 where sessionkey != ''

exec @return = Users2Get
@UserId = '0',
@sessionkey = @sessionkey,
@message = @message output

select @return, @message