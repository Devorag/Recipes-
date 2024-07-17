create or alter procedure dbo.CookbookDelete(
    @CookbookId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related data
        DELETE FROM CookbookRecipe WHERE CookbookId = @CookbookId

        -- Delete recipe
        DELETE FROM Recipe WHERE RecipeId = @CookbookId;

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