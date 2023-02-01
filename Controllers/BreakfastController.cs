using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace MGQSBreakfast.Controllers
{
    public class BreakfastController : Controller
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        public IActionResult Index()
        {
            var breakfasts = _breakfastService.GetAllBreakFast();
            return View(breakfasts);
        }
    }
}
