create or alter procedure dbo.MeasurementDelete(
    @UnitOfMeasureId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

     BEGIN TRY
        BEGIN TRANSACTION;

        DELETE RecipeIngredient WHERE UnitOfMeasureId = @UnitOfMeasureId

        DELETE UnitOfMeasure WHERE UnitOfMeasureId = @UnitOfMeasureId

        COMMIT TRANSACTION;

        SET @Message = 'Measurement deleted successfully.';
        SET @return = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;

    return @return 
    END CATCH
    
END 
GO


declare @id int 
select top 1 @id = unitofmeasureid from UnitOfMeasure 
exec MeasurementDelete @UnitOfMeasureId = @id 