create or alter procedure dbo.MeasurementGet(
    @UnitOfMeasureId int = 0, 
    @MeasurementType varchar(50) = '',
    @All bit = 0, 
    @IncludeBlank bit = 0
)
as 
begin 
    declare @return int = 0 
    
    select @All = ISNULL(@All, 0), @UnitOfMeasureId = ISNULL(@UnitOfMeasureId,0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select u.UnitOfMeasureId, u.MeasurementType 
    from UnitOfMeasure u
    where u.UnitOfMeasureId = @UnitOfMeasureId 
    or @All = 1 
    or u.MeasurementType like '%' + @MeasurementType + '%'
    union SELECT 0, ''
    where @IncludeBlank = 1 
    order by u.MeasurementType

    return @return 

end 
go 

exec MeasurementGet

