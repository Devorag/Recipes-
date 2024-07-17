create or alter procedure dbo.IngredientDelete(
    @IngredientId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Delete related data
        DELETE FROM RecipeIngredient WHERE IngredientId = @IngredientId

        -- Delete recipe
        DELETE FROM ingredient WHERE IngredientId = @IngredientId

        COMMIT;

        SET @Message = 'Ingredient deleted successfully.';
        SET @return = 0;
    END TRY
    BEGIN CATCH
        ROLLBACK;

    return @return 
    END CATCH
    
END 
GO