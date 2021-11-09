using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DetectBrowser.Models;
using Wangkanai.Detection;

namespace DetectBrowser.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDetection _detection;

        public HomeController(IDetection detection)
        {
            _detection = detection;
        }
        public IActionResult Index()
        {
            string browser_information = _detection.Browser.Type.ToString() +
                                     _detection.Browser.Version;
            string device_information = _detection.Device.Type.ToString();
            ViewBag.Browser = browser_information;
            ViewBag.Device = device_information;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
