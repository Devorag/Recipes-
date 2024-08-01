--AS Name it CookbookUpdate to keep to the same naming convention.
create or alter proc dbo.UpdateCookbook( 
    @CookbookId int output, 
    @UsersId int, 
    @CookbookName varchar(100), 
    @Price decimal (6,2), 
    @Active bit = 1,
    @DateCreated DATETIME2, 
    @Message varchar(500) = ' ' output
)
as 
begin 
    DECLARE @RETURN  int = 0 
    DECLARE @ValidPrice BIT;
    
    SET @Message = '';


    IF (@Price IS NULL OR @Price <= 0)
    BEGIN
        SET @Message = 'Invalid Price. Price must be a positive integer.';
        SET @RETURN = -1;
        RETURN @RETURN;
    END


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