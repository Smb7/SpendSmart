using Microsoft.AspNetCore.Mvc;
using Spendsmart.Models;
using System.Diagnostics;

namespace Spendsmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // needed for the DB
        private readonly ExpenesesDBContext _context;

        public HomeController(ILogger<HomeController> logger, ExpenesesDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // looks for html index 
        public IActionResult Index()
        {
            return View();
        }

        // Create a route for expenses
        public IActionResult Expenses()
        {
            // will return the data so we can see it
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;

            return View(allExpenses);
        }

        // Create route for CreateEdit
        public IActionResult CreateEdit(int? id)
        {
            if (id != null)
            {
                // editing -> load an expense by id
                var expenseInDB = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseInDB);
            }
            
            return View();
        }

        // This is to send the data to an endpoint
        public IActionResult CreateEditForm(Expense model)
        {
            if (model.Id == 0)
            {
                // creating a new id
                // creating a action for form data to be added into db
                _context.Expenses.Add(model);
                
                
            }else
            {
                // editing 
                _context.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult Delete(int id)
        {
            // This will match id and allow for us to delete an id
            var expenseInDB = _context.Expenses.SingleOrDefault(x => x.Id == id);
            // Will remove the id
            _context.Expenses.Remove(expenseInDB); 
            // always save changes
            _context.SaveChanges();
            return RedirectToAction("Expenses");
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
