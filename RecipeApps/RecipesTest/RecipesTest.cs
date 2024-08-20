using NUnit.Framework.Internal;
using System.Configuration;

namespace RecipesTest
{
    public class RecipesTest
    {
        string liveString = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;

        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString(liveString, true);
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            DBManager.SetConnectionString(liveString, false);
            dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        private int GetFirstColumnFirstRowValue(string sql)
        {
            int n = 0;
            DBManager.SetConnectionString(liveString, false);
            n = SQLUtility.GetFirstCFirstRValue(sql);
            return n;
        }

        private void ExecuteSQl(string sql)
        {
            DBManager.SetConnectionString(liveString, false);
            SQLUtility.ExecuteSQL(sql);
            //DBManager.SetConnectionString(liveString, false);
        }

        [Test]
        [TestCase("Turkey", "2017-01-01", "2017-12-24", "2018-01-01")]
        [TestCase("Steak", "2019-01-01", "2019-12-24", "2020-01-01")]
        public void InsertNewRecipe(String recipename, DateTime datedrafted, DateTime datepublished, DateTime datearchived)
        {
            int cuisineId = GetFirstColumnFirstRowValue("select top 1 cuisineId from cuisine");
            Assume.That(cuisineId > 0, "Can't run test, no cuisines in the DB");
            int usersId = GetFirstColumnFirstRowValue("select top 1 usersId from users");
            Assume.That(usersId > 0, "Can't run test, no users in the DB");
            int maxCalories = GetFirstColumnFirstRowValue("select max(calories) from recipe");

            maxCalories = maxCalories + 100;

            TestContext.WriteLine("insert recipe with Calories = " + maxCalories);
            bizRecipe recipe = new();
            recipe.CuisineId = cuisineId;
            recipe.UsersId = usersId;
            recipe.RecipeName = recipename + " " + DateTime.Now;
            recipe.Calories = maxCalories;
            recipe.DateDrafted = datedrafted;
            recipe.DatePublished = datepublished;
            recipe.DateArchived = datearchived;

            recipe.Save();

            int newCalories = GetFirstColumnFirstRowValue("select * from recipe where calories = " + maxCalories);
            int pkid = recipe.RecipeId;

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
            int Calories = GetFirstColumnFirstRowValue("select Calories from recipe where recipeid = " + recipeId);
            TestContext.WriteLine("Calories for recipeid " + recipeId + " is " + Calories);
            Calories = Calories + 1;
            TestContext.WriteLine("Change Calories to " + Calories);
            DataTable dt = Recipes.Load(recipeId);

            dt.Rows[0]["Calories"] = Calories;
            Recipes.Save(dt);

            int newCalories = GetFirstColumnFirstRowValue("select Calories from recipe where recipeid = " + recipeId);
            Assert.IsTrue(newCalories == Calories, "UsersId for recipe (" + recipeId + ") + " + newCalories);
            TestContext.WriteLine("Calories for recipe (" + recipeId + ") = " + newCalories);
        }


        [Test]
        public void ChangeExistingRecipeToInvalidCalories()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            int Calories = GetFirstColumnFirstRowValue("select Calories from recipe where recipeid = " + recipeId);
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

        private DataTable GetRecipeForDelete()
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
where r.recipestatus = 'Drafted'
order by r.recipeid

";
            DataTable dt = GetDataTable(sql);
            return dt;
        }

        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = GetRecipeForDelete();
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }
            Assume.That(recipeId > 0, "There are no recipes in DB, can't run test");

            TestContext.WriteLine($"Existing deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app can delete recipe with id = {recipeId}");
            bizRecipe recipe = new();
            recipe.Load(recipeId);
            recipe.Delete();
            DataTable dtAfterDelete = GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count == 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }

        [Test]
        public void DeleteRecipeById()
        {
            DataTable dt = GetRecipeForDelete();
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }
            Assume.That(recipeId > 0, "There are no recipes in DB, can't run test");

            TestContext.WriteLine($"Existing deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app can delete recipe with id = {recipeId}");
            bizRecipe recipe = new();
            recipe.Delete(recipeId);
            DataTable dtAfterDelete = GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count == 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }

        [Test]
        public void DeleteRecipeByDataTable()
        {
            DataTable dt = GetRecipeForDelete();
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }
            Assume.That(recipeId > 0, "There are no recipes in DB, can't run test");

            TestContext.WriteLine($"Existing deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app can delete recipe with id = {recipeId}");
            bizRecipe recipe = new();
            recipe.Delete(dt);
            DataTable dtAfterDelete = GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count == 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }

        //[Test]
        public void DeleteRecipeWithForeignConstraints()
        {
            string sql = @"
select r.recipeid, r.recipename, r.recipestatus
from recipe r 
where r.recipename like '%butter%'
";
            DataTable dt = GetDataTable(sql);
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
            bizRecipe recipe = new();
            recipe.Delete(dt);

            DataTable dtAfterDelete = GetDataTable("select * from recipe r where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count > 0, "record with recipeid " + recipeId + " exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + " does not exist in DB");
        }


        //[Test]
        public void DeleteNonDeletableRecipe()
        {
            string sql = @"
SELECT TOP 1 r.recipeid, r.RecipeName, r.RecipeStatus 
FROM recipe r 
WHERE 
    r.RecipeStatus <> 'Drafted' 
    and DATEDIFF(day, r.DateArchived, GETDATE()) <= 30";

            DataTable dt = GetDataTable(sql);
            int recipeId = 0;
            string recipeDesc = "";

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["recipeid"];
                recipeDesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeStatus"];
            }

            Assume.That(recipeId > 0, "No recipes in DB that are non-deletable based on the business rules, can't run test");

            TestContext.WriteLine($"Existing non-deletable recipe in DB with id = {recipeId}, {recipeDesc}");
            TestContext.WriteLine($"Ensure that app cannot delete recipe with id = {recipeId}");

            Exception ex = Assert.Throws<Exception>(() => Recipes.Delete(dt));
            TestContext.WriteLine(ex.Message);

            DataTable dtAfterDelete = GetDataTable($"SELECT * FROM recipe r WHERE r.recipeid = {recipeId}");
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
            bizRecipe recipe = new();
            recipe.Load(recipeId);
            int loadedId = recipe.RecipeId;
            string RecipeName = recipe.RecipeName;
            Assert.IsTrue(loadedId == recipeId && RecipeName != "", loadedId + " <> " + recipeId + " RecipeName = " + RecipeName);
            TestContext.WriteLine("Loaded recipe (" + loadedId + ") = " + recipeId + " RecipeName = " + RecipeName);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetListOfRecipes(bool includeblank)
        {
            int recipeCount = GetFirstColumnFirstRowValue("select total = count(*) from recipe");
            if (includeblank == true) { recipeCount = recipeCount + 1; }
            Assume.That(recipeCount > 0, "No recipes in DB, can't test");
            TestContext.WriteLine("Num of Recipes in DB = " + recipeCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + recipeCount);
            bizRecipe r = new();
            var lst = r.GetList(includeblank);
            Assert.IsTrue(lst.Count == recipeCount, "num rows returned by app (" + lst.Count + ") <> " + recipeCount);
            TestContext.WriteLine("Number of rows in Recipes return by app = " + lst.Count);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetListOfCuisines(bool includeblank)
        {
            int cuisineCount = GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            if (includeblank == true) { cuisineCount = cuisineCount + 1; }
            Assume.That(cuisineCount > 0, "No cuisines in DB, can't test");
            TestContext.WriteLine("Num of Cuisines in DB = " + cuisineCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + cuisineCount);
            bizCuisine c = new();
            var lst = c.GetList(includeblank);
            Assert.IsTrue(lst.Count == cuisineCount, "num rows returned by app (" + lst.Count + ") <> " + cuisineCount);
            TestContext.WriteLine("Number of rows in Cuisines return by app = " + lst.Count);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetListOfUsers(bool includeblank)
        {
            int usersCount = GetFirstColumnFirstRowValue("select total = count(*) from users");
            if (includeblank == true) { usersCount = usersCount + 1; };
            Assume.That(usersCount > 0, "No users in DB, can't test");
            TestContext.WriteLine("Num of users in DB = " + usersCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + usersCount);
            bizUsers u = new();
            var lst = u.GetList(includeblank);
            Assert.IsTrue(lst.Count == usersCount, "num rows returned by app (" + lst.Count + ") <> " + usersCount);
            TestContext.WriteLine("Number of rows in Users return by app = " + lst.Count);
        }


        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetListOfIngredients(bool includeblank)
        {
            int ingredientCount = GetFirstColumnFirstRowValue("select total = count(*) from ingredient");
            if (includeblank == true) { ingredientCount = ingredientCount + 1; };
            Assume.That(ingredientCount > 0, "No ingredients in DB, can't test");
            TestContext.WriteLine("Num of ingredients in DB = " + ingredientCount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + ingredientCount);
            bizIngredient i = new();
            var lst = i.GetList(includeblank);
            Assert.IsTrue(lst.Count == ingredientCount, "num rows returned by app (" + lst.Count + ") <> " + ingredientCount);
            TestContext.WriteLine("Number of rows in Ingredients return by app = " + lst.Count);
        }

        [Test]
        public void SearchCuisines()
        {
            string cuisinename = "e";
            int cuisinecount = GetFirstColumnFirstRowValue($"select total = count(*) from cuisine where cuisinename like '%{cuisinename}%'");
            TestContext.WriteLine("Num of search results in DB = " + cuisinecount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + cuisinecount);
            bizCuisine c = new();
            List<bizCuisine> lst = c.Search(cuisinename);
            Assert.IsTrue(lst.Count == cuisinecount, "num rows returned by search (" + lst.Count + ") <> " + cuisinecount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        [Test]
        public void SearchUsers()
        {
            string usersname = "e";
            int userscount = GetFirstColumnFirstRowValue($"select total = count(*) from users where usersname like '%{usersname}%'");
            TestContext.WriteLine("Num of search results in DB = " + userscount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + userscount);
            bizUsers u = new();
            List<bizUsers> lst = u.Search(usersname);
            Assert.IsTrue(lst.Count == userscount, "num rows returned by search (" + lst.Count + ") <> " + userscount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        [Test]
        public void SearchRecipes()
        {
            string recipename = "e";
            int recipecount = GetFirstColumnFirstRowValue($"select total = count(*) from recipe where recipename like '%{recipename}%'");
            TestContext.WriteLine("Num of search results in DB = " + recipecount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + recipecount);
            bizRecipe r = new();
            List<bizRecipe> lst = r.Search(recipename);
            Assert.IsTrue(lst.Count == recipecount, "num rows returned by search (" + lst.Count + ") <> " + recipecount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        [Test]
        public void SearchIngredient()
        {
            string ingredientname = "e";
            int ingredientcount = GetFirstColumnFirstRowValue($"select total = count(*) from ingredient where ingredientname like '%{ingredientname}%'");
            TestContext.WriteLine("Num of search results in DB = " + ingredientcount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + ingredientcount);
            bizIngredient i = new();
            List<bizIngredient> lst = i.Search(ingredientname);
            Assert.IsTrue(lst.Count == ingredientcount, "num rows returned by search (" + lst.Count + ") <> " + ingredientcount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }


        private int GetExistingRecipeId()
        {
            return GetFirstColumnFirstRowValue("select top 1 recipeid from recipe where DateArchived is null");
        }

        public string GetFirstRowFirstColumnValue(string sql)
        {
            string val = string.Empty;

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    val = dt.Rows[0][0].ToString();
                }
            }
            return val;
        }

    }
}