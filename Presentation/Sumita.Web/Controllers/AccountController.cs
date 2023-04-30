using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Sumita.Web.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sumita.Web.Controllers
{
    [Route("")]
    [Route("/login")]
    public class AccountController : Controller
    {

        //private readonly SignInManager<UserAccount> _signInManager;
        //private readonly UserManager<UserAccount> _userManager;

        public AccountController()
        {
           
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
            //write custom logic here
           //login usin Identity
                //var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userAccount.UserName));
                //identity.AddClaim(new Claim(ClaimTypes.Name, userAccount.UserName));
                //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                //    new ClaimsPrincipal(identity));
                //return RedirectToAction(nameof(HomeController.Index), "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Invalid UserName or Password");
            //    return View();
            //}
            //return View();


            //login using cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim("MyCustomClaim", "my claim value")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
