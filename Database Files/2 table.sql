-- SM Excellent work! 100% See comment, no need to resubmit.

use RecipeDb
go 
drop table if exists CookbookRecipe
drop table if exists Cookbook 
drop table if exists MealCourseRecipe
drop table if exists MealCourse
drop table if exists Meal
drop table if exists Course
drop table if exists RecipeSteps
drop table if exists RecipeIngredient
drop table if exists UnitOfMeasure 
drop table if exists Recipe 
drop table if exists Cuisine 
drop table if exists Ingredient
drop table if exists Users
go 
create table dbo.Users(
    UsersId int not null identity primary key,
    FirstName varchar(100) not null 
        constraint ck_User_FirstName_cannot_be_Blank check(FirstName <> ''),
    LastName varchar(100) not null 
        constraint ck_User_LastName_cannot_be_blank check(LastName <> ''),
    UserName varchar(100) not null 
        constraint ck_User_UserName_Cannot_be_Blank check(UserName <> ''),
    constraint u_Users_UserName unique(UserName)
)    
go 
create table dbo.ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(100) not null 
        constraint ck_ingredient_ingredientName_cannot_be_blank check(IngredientName <> '')
        constraint u_Ingredient_IngredientName unique,
    IngredientPicture as concat('Ingredient', '_', replace(IngredientName, ' ', '_'), '.jpg') persisted 
)
go 
create table dbo.Cuisine(
    CuisineId int not null identity primary key,
    CuisineType varchar(100) not null 
        constraint ck_Cuisine_CuisineType_cannot_be_Blank check(CuisineType <> ''),
        constraint u_Cuisine_CuisineType unique(CuisineType)
)
go 
create table dbo.Recipe(
    RecipeId int not null identity primary key, 
    CuisineID int not null 
        constraint f_Cuisine_Recipe foreign key references Cuisine(CuisineId),
    UsersId int not null 
        constraint f_User_Recipe foreign key references Users(UsersId),
    RecipeName varchar(100) not null 
        constraint ck_recipe_recipeName_Cannot_be_blank check(RecipeName <> '')
        constraint u_Recipe_RecipeName unique,
    Calories int not null 
        constraint ck_recipe_calories_must_be_greater_than_zero check(Calories > 0),
    DateDrafted datetime not null 
        constraint ck_Recipe_DateDrafted_Cannot_be_future_Date check(DateDrafted <= getdate()),
    DatePublished datetime null 
        constraint ck_Recipe_DatePublished_Cannot_be_future_Date check(DatePublished <= getdate()),
    DateArchived datetime null 
        constraint ck_Recipe_DateArchived_Cannot_be_future_Date check(DateArchived <= getdate()),
    RecipeStatus as 
        case 
            when datearchived is not null then 'Archived'
            when datearchived is null and datepublished is not null then 'Published'
            when datearchived is null and datepublished is null then 'Drafted' 
        end,
    RecipePicture as concat('Recipe', '_', replace(RecipeName, ' ', '_'), '.jpg') persisted,
    constraint ck_Recipe_DateDrafted_before_DatePublished_and_DateArchived_and_DatePublished_before_Archived check(DateDrafted<= DatePublished and isnull(DatePublished,DateDrafted) <= DateArchived)
)
go
create table dbo.UnitOfMeasure(
    UnitOfMeasureId int not null identity primary key,
    MeasurementType varchar(50) not null
        constraint u_UnitOfMeasure_MeasurementType unique(MeasurementType) 
        constraint ck_recipe_measurementType_cannot_be_Blank check(MeasurementType <> '')
) 
go
create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null  
        constraint F_Recipe_RecipeIngredient foreign key references Recipe(RecipeId),
    IngredientId int not null 
        constraint f_Ingredients_RecipeIngredient foreign key references Ingredient(IngredientId),
    UnitOfMeasureId int null 
        constraint f_UnitOfMeasure_RecipeIngredient foreign key references UnitOfMeasure(UnitOfMeasureId),
-- SM Don't allow 0. 0.5 > 0
	MeasurementAmount decimal(4,2) not null 
        constraint ck_recipe_MeasurementAmount_cannot_be_a_negative_number check(MeasurementAmount >= 0),
    IngredientSequence int not null 
        constraint ck_RecipeIngredient_IngredientSequence_must_be_greater_than_zero CHECK(IngredientSequence > 0),
    constraint u_RecipeIngredient_RecipeId_IngredientId unique(RecipeID, IngredientId),
    constraint u_RecipeIngredient_RecipeId_IngredientSequence unique(RecipeId, IngredientSequence)
)
go 
create table dbo.RecipeSteps(
    RecipeStepsId int not null identity primary key,
    RecipeId int not null 
        constraint f_Recipe_RecipeSteps foreign key references Recipe(RecipeID),
     Instructions  varchar(500) not null 
        constraint Ck_RecipeSteps_Instructions_cannot_be_blank check(Instructions <> ''),
    StepSequence int not null 
        constraint ck_RecipeSteps_StepSequence_must_be_Greater_than_zero check(StepSequence > 0),
    constraint u_RecipeSteps_RecipeId_StepSequence unique(RecipeId, StepSequence)
)
go
create table dbo.Course(
    CourseId int not null identity primary key,
    CourseType varchar(100) not null 
        constraint ck_Course_CourseType_cannot_be_blank check(CourseType <> '')
        constraint u_course_coursetype unique,
-- SM Should be unique.
    CourseSequence int not null 
        constraint u_Course_CourseSequence unique(CourseSequence)
        constraint ck_Course_CourseSequence_must_be_greater_than_Zero check(CourseSequence > 0),
)
go
create table dbo.Meal(
    MealId int not null identity primary key,
    UsersId int not null 
        constraint f_Users_Meal foreign key references Users(UsersId),
    MealName varchar(100) not null 
        constraint ck_meal_medalname_cannot_be_blank check(MealName <> '')
        constraint u_Meal_MealName unique,
    Active bit not null default 1,
    DateCreated date not null DEFAULT getdate()
        constraint ck_meal_dateCreated_cannot_be_future_Date check(DateCreated <= getdate()),
    MealPicture as concat('Meal', '_', replace(MealName, ' ', '_'), '.jpg') PERSISTED 
)
go 
create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null 
        constraint f_MealCourse_Meal foreign key references Meal(MealId),
    CourseId int not null 
        constraint f_MealCourse_Course foreign key references Course(CourseId),
    constraint u_MealCourse_MealId_CourseID unique(MealId, CourseID),

)
go 
create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null 
        constraint f_MealCourseRecipe_MealCourse foreign key REFERENCES MealCourse(MealCourseId),
    RecipeId int not null 
        constraint f_MealCourseRecipe_Recipe foreign key references Recipe(RecipeId),
    MainDish bit not null,
        constraint u_MealCourseRecipe_MealCourseId_RecipeId unique(MealCourseId, RecipeId)
)
go
create table dbo.Cookbook(
    CookbookId int not null identity primary key,
    UsersId int not null 
        constraint f_cookbook_users foreign key references Users(UsersId),
    CookbookName varchar(200) not null
        CONSTRAINT ck_Cookbook_CookbookName_cannot_Be_Blank check(CookbookName <> '')
        constraint u_Cookbook_CookbookName unique,
    Price decimal (6,2)
        constraint ck_Cookbook_Price_must_be_greater_than_Zero check(Price > 0),
    Active bit not null default 1, 
    DateCreated date not null default getdate(),
        constraint ck_Cookbook_DateCreated_cannot_be_future_Date check(DateCreated <= getdate()),
    CookbookPicture as concat('Cookbook', '_', replace(CookbookName, ' ', '_'), '.jpg') persisted
)
go 
create table dbo.CookbookRecipe(
    CookbookRecipeId int not null identity primary key,
    RecipeId int not null 
        constraint f_CookbookRecipe_Recipe foreign key references Recipe(RecipeId),
    CookbookId int not null 
        constraint f_CookbookRecipe_Cookbook foreign key references Cookbook(CookbookID),
    RecipeSequence int not null 
        constraint ck_CookbookRecipe_RecipeSequence_must_be_Greater_than_Zero check(RecipeSequence > 0)
    constraint u_CookbookRecipe_RecipeId_CookbookId unique(RecipeId, CookbookId),
    constraint u_CookbookRecipe_CookbookId_RecipeSequence unique(CookbookId, RecipeSequence)
)
go 
