using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repositories;
using UserManagement.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserManagementHelper _iUserManagementHelper;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }
        [HttpPost]
        [Route("UserRegister")]

        public async Task<IActionResult> UserRegister(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UserRegister(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        [Route("UserLogin/{userName}/{password}")]

        public async Task<IActionResult> UserLogin(string userName, string password)
        {
            try
            {
                UserDetails user = await _iUserManagementHelper.UserLogin(userName, password);
                if (user == null)
                    return Ok("Invalid User");
                else
                    return Ok(user);
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }




        [HttpPut]
        [Route("EditProfile")]

        public async Task<IActionResult> EditProfile(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UpdateProfile(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ViewProfile/{userId}")]

        public async Task<IActionResult> ViewProfile(string userId)
        {
            try
            {
                return Ok(await _iUserManagementHelper.ViewProfile(userId));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
