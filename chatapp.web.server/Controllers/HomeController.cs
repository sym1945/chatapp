using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using chatapp.web.server.Data;
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
        protected ApplicationDbContext _Context;

        #endregion

        public HomeController(ApplicationDbContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            _Context.Database.EnsureCreated();

            if (!_Context.Settings.Any())
            {
                
            }

            return View();
        }
    }
}
