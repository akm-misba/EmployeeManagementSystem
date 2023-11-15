using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository; 
        }

        public IActionResult Index()
        {
            var data = _departmentRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

            var data = new Department()
                {
                    
                    ComId = model.ComId,
                    
                    DeptName = model.DeptName, 

                   

                };
                _departmentRepository.Add(data);
            return RedirectToAction(nameof(Index));




        }
        public IActionResult Edit(int id)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _departmentRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Department model)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _departmentRepository.GetById(model.DeptId);
           

            data.DeptId= model.DeptId;
            data.ComId = model.ComId;
            data .DeptName= model.DeptName;
            

            _departmentRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult Delete(int id)
        {
            var data = _departmentRepository.GetById(id);
            _departmentRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
