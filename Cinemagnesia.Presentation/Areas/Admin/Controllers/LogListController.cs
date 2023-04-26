using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using System.Linq;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogListController : Controller
    {
        private readonly Serilog.ILogger _logger;

        public LogListController(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var logEvents = _logger.readform
            //    .SqlServer("YourConnectionString", "YourTableName")
            //    .CreateLogger()
            //    .ReadLogEvents()
            //    .ToList();

            //return View(logEvents);
            return View();
        }
    }
}
