create or alter procedure dbo.RecipeStepsGet(
    @RecipeStepsId int = 0,
    @RecipeId int = 0,
    @All bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin  
    declare @return int = 0 

    select @All = isnull(@All,0), @RecipeStepsId = ISNULL(@RecipestepsId,0), @RecipeId = ISNULL(@RecipeId,0)

    select  rs.RecipeStepsId, rs.RecipeId, rs.Instructions, rs.StepSequence
    from RecipeSteps rs
    where rs.RecipeStepsId = @RecipeStepsId 
    or @All = 1 
    or rs.recipeid = @RecipeId 
    order by rs.stepsequence

    return @return 

end 
go 

exec RecipeStepsGet @All = 1 