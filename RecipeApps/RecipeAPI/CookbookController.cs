using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public List<bizCookbook> GetCookbooks()
        {
            return new bizCookbook().GetList(); 
        }

        [HttpGet("{calories:int:min(0)}")]
        public List<bizCookbookRecipe> GetCookbookRecipes(int calories)
        {
            return new bizCookbookRecipe().LoadByCookbookCalories(calories);
        }
    }
}

