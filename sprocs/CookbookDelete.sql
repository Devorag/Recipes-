create or alter procedure dbo.CookbookDelete(
    @CookbookId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM CookbookRecipe WHERE CookbookId = @CookbookId

        DELETE FROM Cookbook WHERE CookbookId = @CookbookId;

        COMMIT;

        SET @Message = 'Cookbook deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;


    return @return    
    END CATCH
end
go

declare @id int 
select top 1 @id = CookbookId from Cookbook 
exec CookbookDelete @CookbookId = @id 