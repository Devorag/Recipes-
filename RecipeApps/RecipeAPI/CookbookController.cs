using CPUFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;
using System.Data.SqlClient;
using System.Data;

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

        [HttpGet("{id:int:min(0)}")]
        public List<bizCookbookRecipe> GetCookbookRecipes(int id)
        {
            bizCookbook c = new bizCookbook();
            c.Load(id); ;
            if (c == null)
            {
                return new List<bizCookbookRecipe>();
            }
            return new bizCookbookRecipe().LoadByCookbookId(id);
        }
    }
}

