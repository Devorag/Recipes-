create or alter procedure dbo.MeasurementUpdate(
	@UnitOfMeasureId int  output,
	@MeasurementType varchar (20),
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0
 
	select @UnitOfMeasureId = isnull(@UnitOfMeasureId,0)
	
	if @UnitOfMeasureId = 0
	begin
		insert UnitOfMeasure(MeasurementType)
		values(@MeasurementType)

		select @UnitOfMeasureId= scope_identity()
	end
	else
	begin
		update UnitOfMeasure
		set
			MeasurementType = @MeasurementType
		where UnitOfMeasureId = @UnitOfMeasureId
	end
	
	return @return
end
go