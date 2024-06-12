using Microsoft.AspNetCore.Mvc;
using SB.ViewModels;

namespace SB.Controllers
{
    public class BookCategoryMore : Controller
    {
        public IActionResult Index(int idBook)
        {
            SwapBookDbContext dbContext = new SwapBookDbContext();

            return View(dbContext.Books.Where(b=>b.Id==idBook).Select(e=>new BookVM() { Author=e.Author
                , Price=e.Price , Info =e.Info , Swap=(e.Swap==1?true:false) , Title = e.Title 
                , Category= (e.IdCatalogNavigation.Value) ?? "Not Specified"}).ToList());
        }
    }
}
