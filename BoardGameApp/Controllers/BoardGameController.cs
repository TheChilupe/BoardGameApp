
using BoardGameApp.Data;
using BoardGameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameApp.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly GameContext _context;
        public BoardGameController(GameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.BoardGames.Include(p => p.Publisher).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BoardGameModel boardGame)
        {
            if (ModelState.IsValid)
            {

                boardGame.PublisherId = GetPublisher(boardGame.NewPublisher);
                _context.BoardGames.Add(boardGame);
                _context.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(boardGame);

        }

        public IActionResult Edit(int id)
        {
            var game = _context.BoardGames.Include(g => g.Publisher).FirstOrDefault(g => g.Id ==id);
            return View(game);
        }
        [HttpPost]
        public ActionResult Edit(int id, BoardGameModel game)
        {
            if (ModelState.IsValid)
            {
                game.PublisherId = GetPublisher(game.NewPublisher);
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public IActionResult Details(int id)
        {
            var game = _context.BoardGames.Where(g => g.Id == id).Include(b => b.Publisher).FirstOrDefault();
            return View(game);
        }

        public IActionResult Delete(int id)
        {
            var game = _context.BoardGames.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var game = _context.BoardGames.Find(id);
            _context.BoardGames.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public int GetPublisher(string publisher)
        {
            PublisherModel? pub = null;
            pub = _context.Publishers.Where(p => p.Name.ToLower() == publisher.ToLower()).FirstOrDefault();
            if(pub == null)
            {
                pub = new PublisherModel { Name = publisher };
                _context.Publishers.Add(pub);
                _context.SaveChanges();
            }
            return pub.Id;
        }

    }
}
