using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var models = new List<ContactModel>();
            for (var i = 0; i < 20; i++)
            {
                var sString = GenerateUniqueString();
                var model = new ContactModel();
                model.FirstName = $"{sString}-F";
                model.LastName = $"{sString}-L";
                model.GivenName = $"{model.FirstName}{model.LastName}";
                models.Add(model);
            }

            return View(models);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        string GenerateUniqueString()
        {
            var result = "";
            var randomNumber = new byte[8];
            var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(randomNumber);
            result = Convert.ToBase64String(randomNumber);
            result = result.Replace("+", "").Replace("/", "").Replace("=", "").ToUpper();
            return result;
        }
    }

    public class ContactModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GivenName { get; set; }
    }
}