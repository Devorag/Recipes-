using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public List<bizCookbook> Get()
        {
            var c = new bizCookbook().GetList();
            return new bizCookbook().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizCookbook Get(int id)
        {
            bizCookbook c = new bizCookbook();
            c.Load(id);
            return c;
        }
    }
}
