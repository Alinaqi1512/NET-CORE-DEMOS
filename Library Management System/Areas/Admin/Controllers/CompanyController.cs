using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using LibraryBooks.Model.View_Models;
using LibraryBooks.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Library_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //GET
        //public IActionResult Create() 
        //{

        //    return View();
        //}
        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CoverType oj)
        //{
        //    //if (oj.Name == oj.Orders.ToString())
        //    //{
        //    //    //ModelState.AddModelError("CustomError", "Display order can't match the the name");
        //    //    ModelState.AddModelError("name", "Display order can't match the the name");
        //    //}

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.CoverTypeRepository.Add(oj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category created Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(oj);
        //}

        //GET
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            if (id == null || id == 0)
            {
               
                return View(company);
            }
            else
            {
              
                company = _unitOfWork.CompanyRepository.GetFirstOrDefault(u => u.Id == id);
                return View(company);
            }

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            if (ModelState.IsValid)
            {               
                if (obj.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(obj);
                    TempData["success"] = "Company Created Successfully";
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(obj);
                    TempData["success"] = "Company updated Successfully";
                }
                _unitOfWork.Save();
                //TempData["success"] = "Company updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }      
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.CompanyRepository.GetAll();
            return Json(new { Data = companyList });

        }
        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.CompanyRepository.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }         
            _unitOfWork.CompanyRepository.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
