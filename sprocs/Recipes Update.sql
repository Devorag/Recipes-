create or alter proc dbo.RecipeUpdate( 
    @RecipeId int output, 
    @CuisineId int, 
    @UsersId int, 
    @RecipeName varchar(100), 
    @Calories int, 
    @DateDrafted DATETIME2, 
    @DatePublished DATETIME2, 
    @DateArchived DATETIME2, 
    @Message varchar(500) = ' ' output
)
as 
begin 
    DECLARE @RETURN  int = 0 

    set @CuisineId = isnull(@CuisineId, 0)
    set @UsersId = isnull(@UsersId, 0)

    if @RecipeId = 0 
    begin 
        insert Recipe(CuisineId, UsersId, RecipeName, Calories, Datedrafted, Datepublished, DateArchived)
        values (@CuisineId, @UsersId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived)

        select @RecipeId = SCOPE_IDENTITY()

        set @Message = 'Recipe saved successfully.'
    end 
    else 
    begin 
        update Recipe 
        set 
            CuisineId = @CuisineId, 
            UsersId = @UsersId, 
            RecipeName = @RecipeName,
            Calories = @Calories, 
            DateDrafted = @DateDrafted, 
            DatePublished = @DatePublished,
            DateArchived = @DateArchived
        where RecipeId = @RecipeId
        set @Message = 'Recipe updated successfully.'
    end 

    return @RETURN 
end
go
