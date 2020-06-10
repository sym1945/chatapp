using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using chatapp.web.server.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace chatapp.web.server.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDbContext mContext;

        /// <summary>
        /// The manager for handling users creation, deletion, seraching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        public IActionResult Index()
        {
            mContext.Database.EnsureCreated();

            if (!mContext.Settings.Any())
            {

            }

            return View();
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "youngmin",
                Email = "sym1945@gmail.com"
            }, "password");

            if (result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User was creation failed", "text/html");
        }

        /// <summary>
        /// Private area. No Peeking
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }


        [Route("logout")]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("done");
        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="returnUrl">The url to return to if successfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LogInAsync(string returnUrl)
        {
            // Sign out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // Sign user in with the valid credentials
            var result = await mSignInManager.PasswordSignInAsync("youngmin", "password", true, false);

            // if successful...
            if (result.Succeeded)
            {
                // If we have no returl URL...
                if (string.IsNullOrEmpty(returnUrl))
                    // Go to home
                    return RedirectToAction(nameof(Index));
                else
                    // Otherwise, go to the returl URL
                    return Redirect(returnUrl);
            }

            return Content("Failed to login", "text/html");
        }

    }
}
