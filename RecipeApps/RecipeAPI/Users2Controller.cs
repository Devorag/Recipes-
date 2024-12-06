using CPUFramework;
using Microsoft.AspNetCore.Mvc;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users2Controller : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(bizUser userobj)
        {
            try
            {
                userobj.Login();

                return Ok(userobj);
            }
            catch(Exception ex)
            {
                userobj.ErrorMessage = ex.Message;
                return BadRequest(userobj);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout(bizUser userobj)
        {
            try
            {
                userobj.Logout();

                return Ok(userobj);
            }
            catch (Exception ex)
            {
                userobj.ErrorMessage = ex.Message;
                return BadRequest(userobj);
            }
        }
    }
}
