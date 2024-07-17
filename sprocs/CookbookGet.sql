create or alter procedure dbo.CookbookGet (
    @CookbookId int = 0, 
    @CookbookName varchar(100) = '',
    @All bit = 0
)
as 
begin 
        select @CookbookName = nullif(@CookbookName, '')

        select c.CookbookId, u.UsersId, c.CookbookName, c.Price, c.Active, c.DateCreated, c.CookbookPicture
        from Cookbook c 
        left join users u 
        on u.usersid = c.usersid
        where c.CookbookId = @CookbookId 
        or @all = 1 
        or c.CookbookName like '%' + @CookbookName + '%'
        order by c.CookbookName

end 
go

exec CookbookGet @All = 1 


