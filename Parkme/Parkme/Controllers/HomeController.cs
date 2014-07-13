using Newtonsoft.Json;
using Parkme.Core.Manager;
using Parkme.Core.Models;
using Parkme.Models;
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
                return View(new PSearchViewModel());
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

        [HttpPost]
        public ActionResult Index(string location)
        {
            ParkingManager manager = new ParkingManager();
            if (ModelState.IsValid)
            {
                var filePath = HttpContext.Server.MapPath("~/data/dataset_parking_meter.csv");
                PSearchViewModel model = new PSearchViewModel();
                model.IsDefault = true;
                model.Parkings = manager.GetNearybyParking(location, filePath).Take(20).ToList();
                model.SearchTerm = location;
                return View(model);
                // do your stuff like: save to database and redirect to required page.
            }
            

            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}