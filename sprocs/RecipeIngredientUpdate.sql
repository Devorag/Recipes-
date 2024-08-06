create or alter procedure dbo.RecipeIngredientUpdate(
    @RecipeIngredientId int output,
    @RecipeId int ,
    @IngredientId INT,
    @UnitOfMeasureId INT,
    @MeasurementAmount INT,
    @IngredientSequence INT,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 


    select @RecipeIngredientId = ISNULL(@RecipeIngredientId,0) 

    if @RecipeIngredientId = 0 
    begin 
        insert RecipeIngredient(RecipeId, IngredientId, UnitOfMeasureId, MeasurementAmount, IngredientSequence) 
        values (@RecipeId, @IngredientId, @UnitOfMeasureId, @MeasurementAmount, @IngredientSequence)

        select @RecipeIngredientId = SCOPE_IDENTITY() 
    end 
    else 
    begin 
        update RecipeIngredient 
        set 
            RecipeId = @RecipeId,
            IngredientId = @IngredientId,
            UnitOfMeasureId = @UnitOfMeasureId,
            MeasurementAmount = @MeasurementAmount,
            IngredientSequence = @IngredientSequence
        where RecipeIngredientId = @RecipeIngredientId 
    end
 
    return @return 

end 
go 