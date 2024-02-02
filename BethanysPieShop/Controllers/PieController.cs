using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cheese cakes";
            var pieListViewModel = new PieListViewModel(pieRepository.AllPies, "Cheese cakes");
            return View(pieListViewModel);
        }
    }
}
