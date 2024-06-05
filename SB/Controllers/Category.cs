using Microsoft.AspNetCore.Mvc;

namespace SB.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index(int idCategory)
        {

            return View(new SwapBookDbContext().Books.Where(c=>c.Id==idCategory).ToList());
        }
    }
}
