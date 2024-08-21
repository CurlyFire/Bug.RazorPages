using Microsoft.AspNetCore.Mvc;

namespace Bug.RazorPages.RazorClassLibrary
{
    public class RazorClassLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
