
declare @id int 

select top 1 @id = UsersId from Users ORDER BY UsersName desc 

select @id 

exec CreateCookbook @UsersId = @id
 

--select @id
