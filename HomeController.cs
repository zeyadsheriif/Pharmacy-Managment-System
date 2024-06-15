using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseProject.Models;
namespace DatabaseProject.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult pharmpage()
        {
            return View();
        }
    }
}
