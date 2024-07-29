create or alter procedure dbo.RecipeStepsDelete(
    @RecipeStepsId int = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeStepsId = ISNULL(@RecipeStepsId,0)

    delete RecipeSteps where RecipeStepsId = @RecipeStepsId 

    return @return 

end 
go 

declare @id int 
select top 1 @id = recipestepsid from RecipeSteps
exec RecipeStepsDelete @RecipeStepsId = @id 