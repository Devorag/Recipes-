/*
ingredients 
    IngredientId primary key 
    IngredientName varchar(100) not blank 
    unique name
Cuisine
    CuisineId primary key 
    CuisineType Varchar(100) not blank 
Direction
    DirectionId primary key 
    Directions varchar(500) not blank 
    StepSequence int  greater than zero 
User 
    UserId primary key 
    FirstName varchar(100) not blank 
    LastName varchar(100) not blank 
    UserName varchar(100) not blank 
    unique firstname, lastname 
Course
    CourseId primary key 
    CourseType varchar(100)
Recipe
    RecipeId primary key 
    CuisineId foreign key 
    UserId foreign key 
    RecipeName varchar(200) not blank 
    IngredientAmount int greater than zero 
    Calories int greater than zero 
    MeasurementType varchar(50) not null 
    RecipePicture varchar(100)
    RecipeStatus varchar(100) must be drafted, published, archived 
    DateDrafted default date not future date 
    DatePublished default date not future date 
    DateArchived default date not future date 
    unique name 
RecipeIngredient 
    RecipeIngredientId primary key 
    RecipeId foreign key 
    IngredientId foreign key 
RecipeDirection
    RecipeDirectionId primary key
    RecipeId foreign key 
    DirectionId foreign key     
RecipeCourse
    RecipeCourseID primary key 
    RecipeID foreign key 
    CourseId foreign key
Meal
    MealId primary key 
    UserId foreign key 
    MealName varchar(100) not blank 
    MealPicture varchar(100) not blank 
    Active bit 
    DateCreated default date 
    unique name 
MealCourse 
    MealCourseId primary key 
    MealID foreign key 
    CourseId foreign key 
    CourseSequence int greater than zero 
Cookbook   
    CookbookID primay key 
    UserID foreign key 
    Name varchar(100) not blank 
    Price decimal greater than zero 
    CookbookPicture varchar(100) not blank 
    Active bit 
    DateCreated default date not future date 
    unique userId, name 
CookbookRecipe
    RecipeCookbookId primary key
    RecipeID foreign key 
    CookbookID foreign key 

