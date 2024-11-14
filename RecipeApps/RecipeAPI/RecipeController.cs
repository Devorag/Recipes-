using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;
using System.Diagnostics;
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

        [HttpGet("getbyCuisineName/{cuisinename}")]
        public List<bizRecipe> GetRecipesbyCuisine(string cuisinename)
        {
            //var recipestring = ""
            return new bizRecipe().Search(cuisinename);
        }

        [HttpGet("testCuisineName/{cuisinename}")]
        public string TestCuisine(string cuisinename)
        {
            //var recipestring = ""
            return new bizRecipe().TestSearch(cuisinename);
        }

        //[FromForm]

        [HttpPost]
        public IActionResult Post([FromBody]bizRecipe recipe)
        {
            try
            {
                recipe.Save();
                return Ok(new { recipe });
            }
            catch (Exception ex)
            {
                recipe.ErrorMessage = ex.Message;
                return BadRequest( recipe );
            }

        }

        [HttpDelete]
        public IActionResult Delete([FromBody]int id)
        {
            bizRecipe r = new();
            try
            {
                r.recipeDelete(id);
                return Ok(r);
            }
            catch (Exception ex)
            {
                r.ErrorMessage = ex.Message;
                Debug.Print("Delete API encountered an error: " + ex.Message);
                return BadRequest(r);
            }

        }
    }
}
