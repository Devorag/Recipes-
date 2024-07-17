create or alter procedure dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related data
        delete from RecipeSteps where RecipeId = @CuisineId
        delete from RecipeIngredient where RecipeId = @CuisineId
        DELETE FROM Recipe WHERE CuisineId = @CuisineId

        -- Delete recipe
        DELETE FROM Cuisine WHERE CuisineId = @CuisineId;

        COMMIT;

        SET @Message = 'Cuisine deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH

    return @return 
    
END 
GO