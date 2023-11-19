using MeliClon.Models.Request;
using MeliClon.Models.Response;
using MeliClon.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeliClon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthRequest model)
        {
            Response response = new Response();

            var userResponse = _userService.Auth(model);

            if (userResponse.Email == null | userResponse.Token == null)
            {
                response.Success = 0;
                response.Message = "User or Password incorrect";
                return BadRequest(response);
            }
            response.Success = 1;
            response.Message = model.Email + " autenticado correctamente";
            response.Data= userResponse;

            return Ok(response);
        }
    }
}
