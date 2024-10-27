using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        [HttpGet]
        public List<bizCuisine> GetCuisines()
        {
            var c = new bizCuisine().GetList();
            return new bizCuisine().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizCuisine Get(int id)

        {
            bizCuisine c = new bizCuisine();
            c.Load(id);
            return c;
        }
    }
}
