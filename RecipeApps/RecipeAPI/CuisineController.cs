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

        [HttpPost]
        public IActionResult Post(bizCuisine cuisine)
        {
            try {
                cuisine.Save();
                return Ok();
            }
            catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }
 
        }

        [HttpDelete] 
        public IActionResult Delete(int id)
        {   
            try
            {
                bizCuisine c = new();
                c.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new {ex.Message});
            }

        }
    }
}
