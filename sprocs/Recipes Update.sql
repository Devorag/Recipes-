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

    select @RecipeId = isnull(@RecipeId, 0), @CuisineId = nullif(@CuisineId, 0), @UsersId = nullif(@UsersId, 0)

    if @RecipeId = 0 
    begin 
        insert Recipe(CuisineId, UsersId, RecipeName, Calories, Datedrafted, Datepublished, DateArchived)
        values (@CuisineId, @UsersId, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived) 

select @RecipeId = SCOPE_IDENTITY() 
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
end 

    return @return 
    
end
go 
