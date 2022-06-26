using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SwaggerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        /// <summary>
        /// Login with UserId, Password.
        /// </summary>
        /// <param name="userName" example="admin"></param>
        /// <param name="password" example="admin@123"></param>
        /// <returns>Return success/fail status</returns>
        /// <remarks>
        /// **Sample request body:**
        ///
        ///     {
        ///        "UnserName": "admin",
        ///        "PassWord": "admin@123",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="401">Failed/Unauthorized</response>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                await Task.Delay(500);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, "123" ?? "")); // NameIdentifier is the ID for an object
                claims.Add(new Claim(ClaimTypes.Name, userName ?? "")); //  Name is just that a name       


                // implement cookie based login
                var identity = new ClaimsIdentity(claims, "AppCookies");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("AppCookies", claimsPrincipal);
                
                return Ok(new { UserName = userName, token = "token" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Logout.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Failed/Unauthorized</response>
        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout(string userName)
        {
            try
            {
                await HttpContext.SignOutAsync("AppCookies");
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
