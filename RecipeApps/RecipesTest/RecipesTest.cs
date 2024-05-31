

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
            int recipeId = SQLUtility.GetFirstCFirstRValue("select top 1 recipeid from recipe");
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
    }
}