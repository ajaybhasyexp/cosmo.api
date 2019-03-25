using COSMO.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.UserModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace COSMO.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private Members

        private IUserService _userService { get; set; }

        private IUserRoleService _userRoleService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        public UserController(IUserService userService, IUserRoleService userRoleService, ICommonResource commonResource)
        {
            _userService = userService;
            _commonResource = commonResource;
            _userRoleService = userRoleService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ResponseDto<User> Authenticate([FromBody]User userParam)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Authenticate(userParam.UserName, userParam.Password);
                if (response.Data == null)
                {
                    response.IsSuccess = false;
                    response.Message = _commonResource.InvalidUser;
                }
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }           

        }

        [HttpGet("roles")]
        public ResponseDto<List<UserRole>> GetUserRoles()
        {
            ResponseDto<List<UserRole>> response = new ResponseDto<List<UserRole>>(_commonResource);
            try
            {
                response.Data = _userRoleService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        public ResponseDto<List<User>> GetAll()
        {
            ResponseDto<List<User>> response = new ResponseDto<List<User>>(_commonResource);
            try
            {
                response.Data = _userService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDto<User> Get([FromRoute] int id)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpPost]
        public ResponseDto<User> Save([FromBody] User user)
        {
            ResponseDto<User> response = new ResponseDto<User>(_commonResource);
            try
            {
                response.Data = _userService.Save(user);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] User user)
        {
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _userService.Delete(user);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }


        //[HttpGet("userendpoint")]
        //public ResponseDto<User> GetTokenAttributes(string token)
        //{

        //}
    }
}
