create or alter proc dbo.UpdateCookbook( 
    @CookbookId int output, 
    @UsersId int, 
    @CookbookName varchar(100), 
    @Price int, 
    @Active bit = 1,
    @DateCreated DATETIME2, 
    @Message varchar(500) = ' ' output
)
as 
begin 
    DECLARE @RETURN  int = 0 

    select @CookbookId = isnull(@CookbookId, 0), @UsersId = nullif(@UsersId, 0)

    if @CookbookId = 0 
    begin 
        insert Cookbook(UsersId, CookbookName, Price, Active, DateCreated)
        values (@UsersId, @CookbookName, @Price, @Active, @DateCreated) 

select @CookbookId = SCOPE_IDENTITY() 
end 
else 
begin 
    update Cookbook
    set 
        UsersId = @UsersId, 
        CookbookName = @CookbookName, 
        Price = @Price, 
        Active = @Active,
        DateCreated = @DateCreated
    where CookbookId = @CookbookId
end 

    return @return 
    
end
go  