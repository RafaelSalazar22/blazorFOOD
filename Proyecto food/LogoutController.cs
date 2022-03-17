using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Food_Blazor
{
    [Route("/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        public string ReturnUrl { get; private set; }

        public async Task<IActionResult> OnPost(
            string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Clear the existing external cookie
            await HttpContext
                   .SignOutAsync();
            //CookieAuthenticationDefaults.AuthenticationScheme);

            return LocalRedirect("/");
        }
    }
}
