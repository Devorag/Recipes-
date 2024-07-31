create or alter procedure dbo.RecipeStepsUpdate(
    @RecipestepsId int output,
    @RecipeId int,
    @Instructions varchar(300),
    @StepSequence int,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeStepsId = ISNULL(@RecipeStepsId,0) 

    if @RecipeStepsId = 0 
    begin 
        insert RecipeSteps(RecipeId, Instructions, StepSequence) 
        values (@RecipeId, @Instructions, @StepSequence)

        select @RecipeStepsId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update RecipeSteps 
        set 
            RecipeId = @RecipeId,
            Instructions = @Instructions, 
            StepSequence = @StepSequence
        where RecipeStepsId = @RecipeStepsId 
    end

    return @return 
 
end 
go 