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

        [HttpGet("{id:int:min(0)}")]
        public bizRecipe Get(int id)

        {
            bizRecipe r = new bizRecipe();
            r.Load(id);
            return r;
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

        [HttpPost]
        public IActionResult Post([FromForm]bizRecipe recipe)
        {
            try
            {
                recipe.Save();
                return Ok(new {message = "recipe saved", recipeid = recipe.RecipeId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bizRecipe r = new();
                r.Delete(id);
                return Ok(new { message = "recipe deleted"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }
    }
}
