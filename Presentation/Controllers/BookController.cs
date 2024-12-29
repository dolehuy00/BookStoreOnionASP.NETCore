using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Abstractions;
using Shared;

namespace Presentation.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _cateServ;
        public BookController(IBookService bookService, ICategoryService cateServ)
        {
            _bookService = bookService;
            _cateServ = cateServ;
        }

        private async Task PopulateCategories()
        {
            var categories = await _cateServ.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }

        public async Task<IActionResult> Index()
        {
            var bookDTOs = await _bookService.GetAllFullInfo();
            return View(bookDTOs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookService.GetFullInfo(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Tạo sách mới
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // Cập nhật thông tin sách
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await PopulateCategories();
            var book = await _bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookDTO book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bookService.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> SearchName(string name)
        {
            var books = await _bookService.SearchName(name);
            return View("Index", books);
        }
    }
}
