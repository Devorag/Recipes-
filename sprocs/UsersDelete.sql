create or alter procedure dbo.UserDelete(
    @UsersId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related data
        DELETE FROM Meal WHERE UsersId = @UsersId

        -- Delete recipe
        DELETE FROM Users WHERE UsersId = @UsersId;

        COMMIT;

        SET @Message = 'User deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;

    return @return 
    END CATCH
    
END 
GO