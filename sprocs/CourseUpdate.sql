create or alter procedure dbo.CourseUpdate(
	@CourseId int  output,
	@CourseType varchar (100),
	@CourseSequence int,
	@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @CourseId = isnull(@CourseId, 0)
	
	if @CourseId = 0
	begin
		insert Course(CourseType, CourseSequence)
		values(@CourseType, @CourseSequence)

		select @CourseId= scope_identity()
	end
	else
	begin
		update Course
		set
			CourseType = @CourseType,
			CourseSequence = @CourseSequence
		where CourseId = @CourseId
	end
	 
	return @return
end
go
