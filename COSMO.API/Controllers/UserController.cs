using COSMO.Business.Abstractions;
using COSMO.Models.UserModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace COSMO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; set; }

        private IUserRoleService _userRoleService { get; set; }

        public UserController(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }
        

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.UserName, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("roles")]
        public ResponseDto<List<UserRole>> GetUserRoles()
        {
            ResponseDto<List<UserRole>> response = new ResponseDto<List<UserRole>>
            {
                Data = _userRoleService.GetAll()
            };
            return response;
        }

        //[HttpGet("userendpoint")]
        //public ResponseDto<User> GetTokenAttributes(string token)
        //{

        //}
    }
}
