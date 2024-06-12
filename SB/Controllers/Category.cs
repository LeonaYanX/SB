using Microsoft.AspNetCore.Mvc;
using SB.ViewModels;

namespace SB.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index(int idCategory)
        {

            return View(new SwapBookDbContext().Books.Where(c=>c.Id==idCategory)
                .Select(e=>new BookVM() {Title = e.Title , Author = e.Author , Info =e.Info , Price = e.Price
                ,Swap = (e.Swap== 1?true:false), Src = new string[] {@"data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg=="}}).ToList());
        } //todo dodelat src red dot
    }
}
