create or alter procedure dbo.RecipeStepsUpdate(
    @RecipestepsId int output,
    @RecipeId int,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeStepsId = ISNULL(@RecipeStepsId,0) 

    if @RecipeStepsId = 0 
    begin 
        insert RecipeIngredient(RecipeId) 
        values (@RecipeId)

        select @RecipeStepsId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update RecipeIngredient 
        set 
            RecipeId = @RecipeId 
        where RecipeIngredientId = @RecipeStepsId 
    end

    return @return 

end 
go 