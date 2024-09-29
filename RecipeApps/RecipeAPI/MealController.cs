using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        [HttpGet]
        public List<bizMeal> GetMeals()
        {
            var m = new bizMeal().GetList();
            return new bizMeal().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public bizMeal Get(int id)

        {
            bizMeal m = new bizMeal();
            m.Load(id);
            return m;
        }
    }
}
