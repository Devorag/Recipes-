using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem; 
namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]   
        public List<bizRecipe> GetRecipes()
        {

            var c = new bizRecipe();

            var b = new bizRecipe().GetList();

            return new bizRecipe().GetList();


        }

        [HttpGet("getbyUser/{username}")]
        public List<bizRecipe> GetRecipesbyUser(string username)
        {
            return new bizRecipe().Search(username);
        }

        [HttpGet("getbyCuisine/{cuisinename}")]
        public List<bizRecipe> GetRecipesbyCuisine(string cuisinename)
        {
            return new bizRecipe().Search(cuisinename);
        }

        [HttpGet("meals")]
        public List<bizMeal> GetMeals()
        {
            return new bizMeal().GetList();
        }

        [HttpGet("cookbooks")]
        public List<bizCookbook> GetCookbooks()
        {
            return new bizCookbook().GetList();
        }
    }
}
