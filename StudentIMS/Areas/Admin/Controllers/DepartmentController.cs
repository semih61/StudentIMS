using DataAccess.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace StudentIMS.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public DepartmentController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DepartmentList()
        {
            List<Department> DepartmentList = _unitOfwork.DepartmentRepository.GetAll().ToList();

            return View(DepartmentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfwork.DepartmentRepository.Add(obj);
                _unitOfwork.Save();
                TempData["success"] = "New record added successfully";
                return RedirectToAction("DepartmentList", "Department");
            }


            return View();
        }
        public IActionResult Edit(int? id)
        {
            Department obj = _unitOfwork.DepartmentRepository.Get(obj => obj.Id == id); //Find() sadece primary key'e göre arama yapar

            if (obj is not null)
            {
                return View(obj);
            }

            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Edit(Department obj)
        {

            if (obj is not null)
            {
                _unitOfwork.DepartmentRepository.Update(obj);
                _unitOfwork.Save();
                TempData["success"] = "Record updated succesfully";
                return RedirectToAction("DepartmentList", "Department");
            }
            else
            {
                return NotFound();
            }


        }
        public IActionResult Delete(int id)
        {
            Department obj = _unitOfwork.DepartmentRepository.Get(obj => obj.Id == id);
            /*
             .FirstOrDefault();
             .Where(); öğren             
            */

            if (obj is not null)
            {
                return View(obj);
            }

            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(Department obj)
        {
            if (obj is not null)
            {
                _unitOfwork.DepartmentRepository.Delete(obj);
                _unitOfwork.Save();
                TempData["success"] = "Record deleted succesfully";
                return RedirectToAction("DepartmentList", "Department");
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
