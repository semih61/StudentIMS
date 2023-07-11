using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using DataAccess.Data;
using Models.Models;
using DataAccess.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentIMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public StudentController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StudentList()
        {
            List<Student> studentList = _unitOfwork.StudentRepository.GetAll().ToList();

            return View(studentList);
        }

        public IActionResult Create()
        {
            StudentViewModel _studentViewModel = new StudentViewModel();

            IEnumerable<SelectListItem> DepartmentList = _unitOfwork.DepartmentRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.Depart,
                Value = i.Id.ToString()
                
            });
            _studentViewModel.DepartmentList = DepartmentList;
            _studentViewModel.Student = new Student();
            //ViewData["DepartmentList"] = DepartmentList;
            //ViewBag.DepartmentList = DepartmentList;

            return View(_studentViewModel);
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel obj)
        {
            if (obj.Student.Name == obj.Student.Surname)
            {
                ModelState.AddModelError("Name", "Name and surname connot be equal.");
            }


            if (ModelState.IsValid)
            {
                _unitOfwork.StudentRepository.Add(obj.Student);
                _unitOfwork.Save();
                TempData["success"] = "New record added successfully";
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
				//IEnumerable<SelectListItem> DepartmentList = _unitOfwork.DepartmentRepository.GetAll().Select(i => new SelectListItem
				//{
				//	Text = i.Depart,
				//	Value = i.Id.ToString()

				//});
                //ViewData["DepartmentList"] = DepartmentList;
				//ViewBag.DepartmentList = DepartmentList;
				return View();
			}
			


		}
        public IActionResult Edit(int? id)
        {
            Student obj = _unitOfwork.StudentRepository.Get(obj => obj.Id == id); //Find() sadece primary key'e göre arama yapar

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
        public IActionResult Edit(Student obj)
        {

            if (obj is not null)
            {
                _unitOfwork.StudentRepository.Update(obj);
                _unitOfwork.Save();
                TempData["success"] = "Record updated succesfully";
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return NotFound();
            }


        }
        public IActionResult Delete(int id)
        {
            Student obj = _unitOfwork.StudentRepository.Get(obj => obj.Id == id);
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
        public IActionResult Delete(Student obj)
        {
            if (obj is not null)
            {
                _unitOfwork.StudentRepository.Delete(obj);
                _unitOfwork.Save();
                TempData["success"] = "Record deleted succesfully";
                return RedirectToAction("StudentList", "Student");
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
