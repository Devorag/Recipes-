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

        [HttpGet("{cookbookId:int:min(0)}")]
        public List<bizCookbookRecipe> GetCookbookRecipes(int id)
        {
            return new bizCookbookRecipe().LoadByCookbookId(id);
        }

        //[HttpGet("getbyName/{cookbookname}")]
        //public List<bizCookbookRecipe> GetRecipesbyCookbook(string cookbookname)
        //{
        //    return new bizCookbookRecipe().Search(cookbookname);
        //}
    }
}

