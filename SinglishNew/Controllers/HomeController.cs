using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SinglishNew.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;
using System.Drawing;

namespace SinglishNew.Controllers
{
    public class HomeController : Controller
    {
        Data data = new Data();

        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetData(string txt)
        {
            dynamic dt   = JObject.Parse(txt);
            if(dt["type"]== "Unicode")
                return Json(data.SinhalaTxt = UniConverter.Convert(data.SinglishTxt = dt["SinglishTxt"]));
            else                
                return Json(data.SinhalaTxt = FontConverter.Convert(data.SinglishTxt = dt["SinglishTxt"]));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
