using Microsoft.AspNetCore.Mvc;
using MyMainWebApp.Models;
using System;

namespace MyMainWebApp.Controllers
{
    // /WeatherInfo
    public class WeatherInfoController : Controller
    {
        // Action Method
        // /WeatherInfo/Index
        //      or
        // /WeatherInfo
        public IActionResult Index()
        {
            // return view file in Project/Views/WeatherInfo/Index.cshtml
            return View();
        }
        // Information can be sent from the client in
        // - querystring (url)
        // - body
        // - header of request


        // Controller Actions > Second segment of my url
        // /WeatherInfo/{action}
        [HttpGet]
        public IActionResult Toronto()
        {
            // Option 1 Pass data with the ViewData dictionary
            ViewData["PageTitle"] = "Weather info for TO";
            ViewData["InfoSource"] = "Weather Service of Ontario";

            // Option 2 Pass data with the ViewBag dynamic object
            ViewBag.CurrentTime = DateTime.Now;
            ViewBag.CurrentTimeForDisplay = DateTime.Now.ToString("HH:mm");

            // Option 3 Pass data as a model
            // model = class that represents data
            WeatherInfoViewModel weatherInfo = new WeatherInfoViewModel();
            weatherInfo.City = "Toronto, ON";
            weatherInfo.TempC = "-2 C";
            weatherInfo.Source = "Weather Channel";

            return View(weatherInfo); // html/css/js/c# UI << focus of our module
        }

        [HttpGet] // GET IS THE DEFAULT ONE
        public IActionResult NewYork(string message)
        {
            ContentResult res = new ContentResult();
            res.Content = "Hi there, this is NYC " + message;
            res.StatusCode = 200; // Successful request

            return res;
        }

        [HttpPost]
        public IActionResult QuebecCity([FromHeader] string message, [FromBody] string greetings)
        {
            Forecast forecast = new Forecast();
            forecast.Location = "Quebec City";
            forecast.Label = "It's very snowy today! " + message + " " + greetings;
            forecast.TempC = -18;

            JsonResult res = new JsonResult(forecast);
            res.StatusCode = 200; // successful request
            res.Value = forecast;

            return res;
        }

        // it is discoverable!
        // but it shouldn't.....
        // this is an API endpoint
        [NonAction]
        public string SayHello()
        {
            return "Hello visitor!";
        }
    }
}
