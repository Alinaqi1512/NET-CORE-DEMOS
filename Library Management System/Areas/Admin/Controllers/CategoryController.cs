using LibraryBooks.Data;
using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using LibraryBooks.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Linq;
namespace Library_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public IActionResult Index()
        {
            IEnumerable<Category> retrieveCategories = _unitOfWork.CategoryRepository.GetAll();
            return View(retrieveCategories);
        }
        //GET
        
        
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category oj)
        {
            if (oj.Name == oj.Orders.ToString())
            {
                //ModelState.AddModelError("CustomError", "Display order can't match the the name");
                ModelState.AddModelError("name", "Display order can't match the the name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(oj);
                _unitOfWork.Save();
                TempData["success"] = "Category created Successfully";
                return RedirectToAction("Index");
            }
            return View(oj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var categoryFromDb = _lb.categories.Find(id);
            //var categoryFromDbSingle = _lb.categories.SingleOrDefault(c => c.Name == "Id");
            var categoryFromDbFirst = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category oj)
        {
            if (oj.Name == oj.Orders.ToString())
            {
                //ModelState.AddModelError("CustomError", "Display order can't match the the name");
                ModelState.AddModelError("name", "Display order can't match the the name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(oj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated Successfully";

                return RedirectToAction("Index");
            }
            return View(oj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _lb.categories.Find(id);
            //var categoryFromDbSingle = _lb.categories.SingleOrDefault(c => c.Id == id);
            var categoryFromDbFirst = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}