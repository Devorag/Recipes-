create or alter procedure dbo.StepsGet(
    @StepsId int = 0, 
    @All bit = 0, 
    @IncludeBlank bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 
    
    select @All = ISNULL(@All, 0), @StepsId = ISNULL(@StepsId,0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select r.RecipeStepsId, r.Instructions
    from RecipeSteps r
    where r.RecipeStepsId = @StepsId 
    or @All = 1 
    union SELECT 0, ''
    where @IncludeBlank = 1 
    order by r.Instructions

    return @return 

end 
go 

exec StepsGet @All = 1 