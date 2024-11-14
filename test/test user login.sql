declare @message varchar(500), @return int 

exec @return = UserLogin 
@Username = '',
@password = '',
@message = @message output

select @return, @message

exec @return = UserLogin 
@Username = 'sam',
@password = 'password',
@message = @message output

select @return, @message

