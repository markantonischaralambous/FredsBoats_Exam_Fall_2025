using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Controllers
{
    public class BoatsController : Controller
    {
        private readonly FredsBoatsContext _context;

        public BoatsController(FredsBoatsContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var boats = _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour);
            return View(await boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var boat = await _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour)
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.BoatId == id);

            if (boat == null) return NotFound();

            return View(boat);
        }

        // POST: Boats/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int boatId, string author, string content)
        {
            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(content))
            {
                TempData["Error"] = "Author and content are required.";
                return RedirectToAction(nameof(Details), new { id = boatId });
            }

            var comment = new Comment
            {
                BoatId = boatId,
                Author = author,
                Content = content,
                Createdat = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = boatId });
        }
    }
}