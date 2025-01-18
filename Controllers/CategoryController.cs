using Lab2_TuThiHongDiep_CSE422.Database;
using Lab2_TuThiHongDiep_CSE422.Models;
using Lab2_TuThiHongDiep_CSE422.Models.WebModel;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_TuThiHongDiep_CSE422.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult CategoryManagement()
        {
            List<Category> categories = VirtualDatabase.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category { Id = request.Id, Name = request.Name, Description = request.Description };
                VirtualDatabase.Categories.Add(newCategory);

                return RedirectToAction("CategoryManagement");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCategory(string id)
        {
            var deletedCategory = VirtualDatabase.Categories.FirstOrDefault(d => d.Id == id);
            if (deletedCategory != null)
            {
                VirtualDatabase.Categories.Remove(deletedCategory);
                var relatedDevices = VirtualDatabase.Devices.Where(d => d.CategoryID == id).ToList();
                foreach (var device in relatedDevices)
                {
                    device.CategoryID = "";
                }

            }
            return RedirectToAction("CategoryManagement");
        }
        [HttpGet]
        public IActionResult EditCategory(string id)
        {
            var editedCategory = VirtualDatabase.Categories.FirstOrDefault(c => c.Id == id);
            if (editedCategory != null)
            {
                return View(editedCategory);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditCategory(EditCategoryRequest request)
        {
            var editedCategory = VirtualDatabase.Categories.FirstOrDefault(c => c.Id.Equals(request.Id));
            if (editedCategory != null)
            {
                editedCategory.Name = request.Name;
                editedCategory.Description = request.Description;
            }
            return RedirectToAction("CategoryManagement");
        }
    }
}
