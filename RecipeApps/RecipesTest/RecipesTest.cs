
using NUnit.Framework;
using NUnit.Framework.Internal;
using RecipeSystem;
using System.Data.SqlClient;
using System.Net.Security;

namespace RecipesTest
{
    public class RecipesTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=tcp:dev-devorag.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=devorag;Password=DEVO5401!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }

        [Test]
        [TestCase("Turkey", "2017-01-01", "2017-12-24", "2018-01-01")]
        [TestCase("Popcorn", "2019-01-01", "2019-12-24", "2020-01-01")]
        public void InsertNewRecipe(String recipename, DateTime datedrafted, DateTime datepublished, DateTime datearchived)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineId = SQLUtility.GetFirstCFirstRValue("select top 1 cuisineId from cuisine");
            Assume.That(cuisineId > 0, "Can't run test, no cuisines in the DB");
            int usersId = SQLUtility.GetFirstCFirstRValue("select top 1 usersId from users");
            Assume.That(usersId > 0, "Can't run test, no users in the DB");
            int maxCalories = SQLUtility.GetFirstCFirstRValue("select max(calories) from recipe");

            maxCalories = maxCalories + 100;

            TestContext.WriteLine("insert recipe with Calories = " + maxCalories);

            r["CuisineId"] = cuisineId;
            r["UsersId"] = usersId;
            r["Recipename"] = recipename + " " + DateTime.Now;
            r["Calories"] = maxCalories;
            r["DateDrafted"] = datedrafted;
            r["DatePublished"] = datepublished;
            r["DateArchived"] = datearchived;
            Recipes.Save(dt);

            int newCalories = SQLUtility.GetFirstCFirstRValue("select * from recipe where calories = " + maxCalories);
            int pkid = 0;
            if (r["RecipeId"] != DBNull.Value)
            {
               pkid = (int)r["RecipeId"];
            }

            Assert.IsTrue(newCalories > 0, "recipe with Calories = " + maxCalories + " is not found in DB");
            Assert.IsTrue(pkid > 0, "primary key is not updated in datatable");
            TestContext.WriteLine("Recipe with Calories = " + maxCalories + " is found in DB with pk value = " + newCalories);
            TestContext.WriteLine("new primary key = " + pkid);
        }

        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            int Calories = SQLUtility.GetFirstCFirstRValue("select Calories from recipe where recipeid = " + recipeId);
            TestContext.WriteLine("Calories for recipeid " + recipeId + " is " + Calories);
            Calories = Calories + 1;
            TestContext.WriteLine("Change Calories to " + Calories);
            DataTable dt = Recipes.Load(recipeId);

            dt.Rows[0]["Calories"] = Calories;
            Recipes.Save(dt);

            int newCalories = SQLUtility.GetFirstCFirstRValue("select Calories from recipe where recipeid = " + recipeId);
            Assert.IsTrue(newCalories == Calories, "UsersId for recipe (" + recipeId + ") + " + newCalories);
            TestContext.WriteLine("Calories for recipe (" + recipeId + ") = " + newCalories);
        }


        [Test]
        public void ChangeExistingRecipeToInvalidCalories()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            int Calories = SQLUtility.GetFirstCFirstRValue("select Calories from recipe where recipeid = " + recipeId);
            TestContext.WriteLine("Calories for recipeid " + recipeId + " is " + Calories);
            Calories = Calories - 1000;
            TestContext.WriteLine("Change Calories to " + Calories);
            DataTable dt = Recipes.Load(recipeId);

            dt.Rows[0]["Calories"] = Calories;

            Exception ex = Assert.Throws<Exception>(() => Recipes.Save(dt), "Calories can only be more than zero");
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToInvalidRecipeName()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            string recipeName = GetFirstRowFirstColumnValue("select top 1 recipename from recipe where recipeid <> " + recipeId);
            TestContext.WriteLine("Change recipeid " + recipeId + " recipeName to " + recipeName);

            DataTable dt = Recipes.Load(recipeId);
            dt.Rows[0]["RecipeName"] = recipeName;

            Exception ex = Assert.Throws<Exception>(() => Recipes.Save(dt), " Recipe Name must be unique");
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipe()
        {
            string sql = @"
select top 1 r.recipeid, r.recipename, r.recipestatus
from recipe r 
left join recipesteps rs 
on rs.recipeid = r.recipeid 
left join recipeingredient ri 
on ri.recipeid = r.recipeid
left join mealcourserecipe mc 
on mc.recipeid = r.recipeid
left join cookbookrecipe cr 
on cr.recipeid = r.recipeid 
where ri.recipeingredientid is null
and mc.mealcourserecipeid is null 
and cr.cookbookrecipeid is null 
order by r.recipeid
";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }
            Assume.That(dt.Rows.Count > 0, "There are no recipes in DB that do not have instructions, can't run test");

            TestContext.WriteLine($"Existing deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app can delete recipe with id = {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipes.Delete(dt, "Cant"));

            DataTable dtAfterDelete = SQLUtility.GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count > 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }

        [Test]
        public void DeleteRecipeWithForeignConstraints()
        {
            string sql = @"
select r.recipeid, r.recipename, r.recipestatus
from recipe r 
where r.recipename like '%chocolate%'
";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }
            Assume.That(dt.Rows.Count > 0, "There are no recipes in DB that do not have instructions, can't run test");

            TestContext.WriteLine($"Existing deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app can delete recipe with id = {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipes.Delete(dt, "Cant"));

            DataTable dtAfterDelete = SQLUtility.GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count > 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }


        [Test]
        public void DeleteNonDeletableRecipe()
        {
            string sql = @"
SELECT TOP 1 r.recipeid, r.RecipeName, r.RecipeStatus 
FROM recipe r 
WHERE 
    r.RecipeStatus <> 'Drafted' 
    and DATEDIFF(day, r.DateArchived, GETDATE()) <= 30";

            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }

            // Assuming that a recipeId was found that should not be deletable
            Assume.That(recipeId > 0, "No recipes in DB that are non-deletable based on the business rules, can't run test");

            TestContext.WriteLine($"Existing non-deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app cannot delete recipe with id = {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipes.Delete(dt, "Cannot delete recipe because it has not been archived for over 30 days or it is not currently drafted."));
            TestContext.WriteLine(ex.Message);

            DataTable dtAfterDelete = SQLUtility.GetDataTable($"SELECT * FROM recipe r WHERE r.recipeid = {recipeId}");
            Assert.IsTrue(dtAfterDelete.Rows.Count > 0, $"Record with recipeid {recipeId} should still exist in DB");

            TestContext.WriteLine($"Record with recipeId = {recipeId} exists in DB");
        }






        [Test] 
        public void LoadRecipe()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe with id = " + recipeId);
            TestContext.WriteLine("Ensure that app loads recipe " + recipeId);
            DataTable dt = Recipes.Load(recipeId);
            int loadedId = (int)dt.Rows[0]["RecipeId"];
            Assert.IsTrue(loadedId == recipeId, (int)dt.Rows[0]["RecipeId"] + " <> " + recipeId);
            TestContext.WriteLine("Loaded recipe (" + loadedId + ") = " + recipeId);
        }


        [Test]
        public void GetListOfCuisines()
        {
            int cuisineCount = SQLUtility.GetFirstCFirstRValue("select total = count(*) from cuisine");
            Assume.That(cuisineCount > 0, "No cuisines in DB, can't test");
            TestContext.WriteLine("Num of Cuisines in DB = " + cuisineCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + cuisineCount);

            DataTable dt = Recipes.GetCuisineList();

            Assert.IsTrue(dt.Rows.Count == cuisineCount,"num rows returned by app (" + dt.Rows.Count + ") <> " + cuisineCount);

            TestContext.WriteLine("Number of rows in Cuisines return by app = " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int usersCount = SQLUtility.GetFirstCFirstRValue("select total = count(*) from users");
            Assume.That(usersCount > 0, "No users in DB, can't test");
            TestContext.WriteLine("Num of users in DB = " + usersCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + usersCount);

            DataTable dt = Recipes.GetUsersList();

            Assert.IsTrue(dt.Rows.Count == usersCount, "num rows returned by app (" + dt.Rows.Count + ") <> " + usersCount);

            TestContext.WriteLine("Number of rows in Users return by app = " + dt.Rows.Count);
        }

        //[Test] 

        //public void GetFirstRecipe()
        //{
         //   string Recipe = GetFirstRowFirstColumnValue("select recipename from recipe order by datedrafted");
         //   TestContext.WriteLine("Name of recipe in DB = " + Recipe);

        //}

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstCFirstRValue("select top 1 recipeid from recipe");
        }

        public string GetFirstRowFirstColumnValue(string sql)
        {
            string val = string.Empty;

            DataTable dt = SQLUtility.GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0) {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    val = dt.Rows[0][0].ToString();
                }
            }
            return val;
        }
        
    }
}