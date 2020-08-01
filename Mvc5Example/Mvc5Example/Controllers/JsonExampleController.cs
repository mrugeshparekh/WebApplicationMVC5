using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Mvc5Example.Models;
using Newtonsoft.Json;

namespace Mvc5Example.Controllers
{
    public class JsonExampleController : Controller
    {
        // GET: JsonExample
        public ActionResult Index()
        {
            var model = new JsonExampleModel();
            model.AvailableLanguageIds = GetAvailableLanguageId();

            return View(model);
        }

        private List<SelectListItem> GetAvailableLanguageId()
        {
            var listOfSyllabusWiseModel = JsonConvert.DeserializeObject<List<SyllabusWiseDemoModel>>(
                System.IO.File.ReadAllText(@"D:\Temp\syllabuswisedemo.json"));

            return listOfSyllabusWiseModel.DistinctBy(x => x.Name).Select(x =>
                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LangId
                }).ToList();
        }
    }
}