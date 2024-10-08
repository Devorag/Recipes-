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

    }
}
