using Microsoft.AspNetCore.Mvc;
using System;

namespace MyMainWebApp.Controllers
{
    // /day
    [Route("Day")]
    public class DateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("{offset}")] // /day/offset value e.g. /day/1
        public IActionResult Day(int offset) {
            var source = RouteData.DataTokens["source"] ?? "";

            ContentResult res = new ContentResult();
            res.Content = DateTime.Now.AddDays(offset).ToLongDateString() + " " + source.ToString();

            return res;
        }
    }
}
