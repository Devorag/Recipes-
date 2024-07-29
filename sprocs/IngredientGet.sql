create or alter procedure dbo.IngredientGet(
    @IngredientId int = 0, 
    @All bit = 0, 
    @IncludeBlank bit = 0, 
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 
    
    select @All = ISNULL(@All, 0), @IngredientId = ISNULL(@IngredientId,0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select i.IngredientId, i.IngredientName
    FROM ingredient i 
    where i.IngredientId = @IngredientId 
    or @All = 1 
    union SELECT 0, ''
    where @IncludeBlank = 1 
    order by i.IngredientName

    return @return 

end 
go 

exec IngredientGet @All = 1 