using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;
namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public List<bizUsers> Get()
        {
            return new bizUsers().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizUsers Get(int id)
        {
            bizUsers u = new bizUsers();
            u.Load(id);
            return u;
        }
    }
}
