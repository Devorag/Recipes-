create or alter procedure dbo.RecipeIngredientUpdate(
    @RecipeIngredientId int output,
    @RecipeId int ,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeIngredientId = ISNULL(@RecipeIngredientId,0) 

    if @RecipeIngredientId = 0 
    begin 
        insert RecipeIngredient(RecipeId) 
        values (@RecipeId)

        select @RecipeIngredientId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update RecipeIngredient 
        set 
            RecipeId = @RecipeId
        where RecipeIngredientId = @RecipeIngredientId 
    end

    return @return 

end 
go 