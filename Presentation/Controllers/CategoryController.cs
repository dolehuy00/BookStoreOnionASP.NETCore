using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;

namespace Web.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cateServ;

        public CategoryController(ICategoryService cateServ)
        {
            _cateServ = cateServ;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var categoryDTOs = await _cateServ.GetAllCategories();
        //    return View(categoryDTOs);
        //}

        //public async Task<IActionResult> Detail(int id)
        //{
        //    var category = await _cateServ.Get(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoryDTO category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _cateServ.Add(category);
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        //// Cập nhật thông tin sách
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var category = await _cateServ.Get(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, CategoryDTO category)
        //{
        //    if (id != category.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        await _cateServ.Update(category);
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _cateServ.Delete(id);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public async Task<IActionResult> SearchName(string name)
        //{
        //    var categorys = await _cateServ.SearchName(name);
        //    return View("Index", categorys);
        //}
    }
}
