using Microsoft.AspNetCore.Mvc;
using OrderCRUD.BLL.DTO;
using OrderCRUD.UI.Models;
using System.Diagnostics;

namespace OrderCRUD.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public ActionResult MakeOrder (int? id)
        {
            
                return View();   
            
            
        }

        [HttpPost]
        public ActionResult MakeOrder (OrderViewModel order)
        {
            var orderDto = new OrderDTO
            {
                Date = order.Date,
                Id = order.Id,
                Number = order.Number,
            };
            return View (order);
        }

    }
}