declare @Message varchar(500) = '', @return int, @cuisineid int, @usersid int, @recipeid int

select top 1 @cuisineid = cuisineid from cuisine 
select top 1 @usersid = usersid from users 

exec @return = RecipesUpdate 
    @RecipeId = @recipeid output, 
    @cuisineid = @cuisineid, 
    @usersid = @usersid, 
    @RecipeName = 'Waferss',
    @Calories = 500, 
    @DateDrafted = '1/1/23',
    @DatePublished = '5/5/23', 
    @DateArchived = '6/6/24', 
    @Message = @Message output 

select @return, @Message, @recipeid

select top 1 * from recipe r where recipeid = @recipeid

delete recipe where RecipeId = @recipeid 
    