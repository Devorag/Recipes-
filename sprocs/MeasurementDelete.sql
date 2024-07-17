create or alter procedure dbo.MeasurementDelete(
    @UnitOfMeasureId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @UnitOfMeasureId = ISNULL(@UnitOfMeasureId,0)

    delete UnitOfMeasure where UnitOfMeasureId = @UnitOfMeasureId

    return @return 
    
END 
GO