using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Parkme.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + "Briabane") as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var results = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());
                var Lat = results.results[0].geometry.location.lat;
                var Long = results.results[0].geometry.location.lng;
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}