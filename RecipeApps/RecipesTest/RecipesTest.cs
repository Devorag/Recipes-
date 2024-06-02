

using NUnit.Framework.Internal;

namespace RecipesTest
{
    public class RecipesTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true");
        }

        [Test]
        [TestCase("Sweet potato salad", 200, "2017-01-01", "2017-12-24", "2018-01-01")]
        [TestCase("Peanut butter chews", 450, "2019-01-01", "2019-12-24", "2020-01-01")]
        public void InsertNewRecipe(string recipename, int calories, DateTime datedrafted, DateTime datepublished, DateTime datearchived)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineId = SQLUtility.GetFirstCFirstRValue("select top 1 cuisineId from cuisine");
            int usersId = SQLUtility.GetFirstCFirstRValue("select top 1 usersId from users");
            Assume.That(cuisineId > 0, "Can't run test, no cuisines in the DB");

            r["CuisineId"] = cuisineId;
            r["UsersId"] = usersId;
            r["Recipename"] = recipename;
            r["Calories"] = calories;
            r["DateDrafted"] = datedrafted;
            r["DatePublished"] = datepublished;
            r["DateArchived"] = datearchived;
            Recipes.Save(dt);

            int newid = SQLUtility.GetFirstCFirstRValue("select * from recipe where recipename = " + "Sweet potato salad");

            Assert.IsTrue(newid > 0, "recipe with recipename = " + "Sweet potato salad" + "is not found in DB");
            TestContext.WriteLine("Recipe with recipename = " + "Sweet potato salead" + " is found in DB with pk value = " + newid);
        }

        [Test] 
        public void ChangeExistingRecipeUsersId()
        {
            int recipeId = GetExistingRecipeId();
            Assume.That(recipeId > 0, "No recipes in DB, can't run test");
            int UsersId = SQLUtility.GetFirstCFirstRValue("select UsersId from recipe where recipeid = " + recipeId);
            TestContext.WriteLine("UsersId for recipeid " + recipeId + " is " + recipeId);
            UsersId = UsersId + 1;
            TestContext.WriteLine("Change yearpublisehd to " + UsersId);
            DataTable dt = Recipes.Load(recipeId);

            dt.Rows[0]["UsersId"] = UsersId;
            Recipes.Save(dt);

            int newUsersId = SQLUtility.GetFirstCFirstRValue("select UsersId from recipe where recipeid = " + recipeId);
            Assert.IsTrue(newUsersId == UsersId, "UsersId for recipe (" + recipeId + ") + " + newUsersId);
            TestContext.WriteLine(" UsersId for recipe (" + recipeId + ") + " + newUsersId);
        }

        [Test] 
        public void DeletePresident()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, r.recipename  from recipe r where r.datearchived is not null");
            int recipeId = 0;
            string recipedesc = "";
            if(dt.Rows.Count > 0) 
            {

                recipeId =(int)dt.Rows[0]["recipeId"];
                recipedesc = dt.Rows[0]["Calories"] + " " + dt.Rows[0]["RecipeStatus"];
            }

            Assume.That(recipeId > 0, "No recipes in DB that has been archived, can't run test");
            TestContext.WriteLine("existing recipe that has been archived. with id = " + recipeId);
            TestContext.WriteLine("ensure that app can delete " + recipeId);
            Recipes.Delete(dt);
            DataTable dtAfterDelete = SQLUtility.GetDataTable("select * from recipe where r.recipeId = " + recipeId);
            Assert.IsTrue(dtAfterDelete.Rows.Count == 0, "record wiht recipeid " + recipeId + "exists in DB");
            TestContext.WriteLine("Record with recipeId  = " + recipeId + "does not exist in DB");
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
            TestContext.WriteLine("Loaded recipe (" + loadedId + ")" + recipeId);
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

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstCFirstRValue("select top 1 recipeid from recipe");
        }
    }
}