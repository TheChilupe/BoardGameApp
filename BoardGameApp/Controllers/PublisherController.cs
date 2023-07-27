using BoardGameApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly GameContext _context;
        public PublisherController(GameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var publishers = _context.Publishers.Include(b => b.BoardGame).ToList();
            return View(publishers);
        }

        public IActionResult Details(int id)
        {
            var publisher
                = _context.Publishers.Where(p => p.Id == id).Include(b => b.BoardGame).FirstOrDefault();
            return View(publisher);
        }

    }
}
