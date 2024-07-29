create or alter procedure dbo.CourseGet(
    @CourseId int = 0, 
    @All bit = 0, 
    @IncludeBlank bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 
    
    select @All = ISNULL(@All, 0), @CourseId = ISNULL(@CourseId,0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select c.CourseId, c.CourseType, c.CourseSequence
    from Course c 
    where c.CourseId = @CourseId 
    or @All = 1 
    union SELECT 0, '', 0
    where @IncludeBlank = 1 
    order by c.CourseType

    return @return 
 
end 
go 