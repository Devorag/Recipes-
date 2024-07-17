create or alter procedure dbo.UserUpdate(
	@UsersId int  output,
	@UserName varchar (100),
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @UsersId = isnull(@UsersId,0)
	
	if @UsersId = 0
	begin
		insert Users(UserName)
		values(@UserName)

		select @UsersId= scope_identity()
	end
	else
	begin
		update Users
		set
			UserName = @UserName
		where UsersId = @UsersId
	end
	
	return @return
end
go