using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using LibraryBooks.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Library_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> retrieveCovers = _unitOfWork.CoverTypeRepository.GetAll();
            return View(retrieveCovers);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType oj)
        {
            //if (oj.Name == oj.Orders.ToString())
            //{
            //    //ModelState.AddModelError("CustomError", "Display order can't match the the name");
            //    ModelState.AddModelError("name", "Display order can't match the the name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypeRepository.Add(oj);
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
            var coverFromDbFirst = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (coverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(coverFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType oj)
        {
            //if (oj.Name == oj.Orders.ToString())
            //{
            //    //ModelState.AddModelError("CustomError", "Display order can't match the the name");
            //    ModelState.AddModelError("name", "Display order can't match the the name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypeRepository.Update(oj);
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
            var coverFromDbFirst = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (coverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(coverFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverTypeRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted Successfully";

            return RedirectToAction("Index");
        }
    }

}

