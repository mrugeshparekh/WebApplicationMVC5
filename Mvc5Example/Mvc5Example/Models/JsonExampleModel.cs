using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Example.Models
{
    public class JsonExampleModel
    {
        public string LanguageId { get; set; }
        public List<SelectListItem> AvailableLanguageIds { get; set; }
    }
}