

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Model;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var item = new Item();
            item.Id = 1;
            item.Description = "Test";
            _context.Items.Add(item);
            return View("Index", _context.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Items.Where(itm => itm.Id == id).Select(itm => itm).FirstOrDefault();
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
