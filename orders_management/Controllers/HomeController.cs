using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;

using test_task.Context;
using test_task.Models;

namespace test_task.Controllers
{
    public class HomeController(ILogger<HomeController> logger, OrderContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly OrderContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult List()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult OrderDetails(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Database.EnsureCreated();

                    var order = new OrderViewModel
                    {
                        SenderCity = model.SenderCity,
                        SenderAddress = model.SenderAddress,
                        RecipientCity = model.RecipientCity,
                        RecipientAddress = model.RecipientAddress,
                        Weight = model.Weight,
                        Weight_Measure = model.Weight_Measure,
                        PickupDate = model.PickupDate
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the order: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
