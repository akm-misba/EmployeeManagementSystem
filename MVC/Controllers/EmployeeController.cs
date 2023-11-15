using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IShiftRepository _shiftRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository, IDesignationRepository designationRepository, IShiftRepository shiftRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository=companyRepository;
            _departmentRepository = departmentRepository;
            _shiftRepository= shiftRepository;
            _designationRepository = designationRepository;
        }
    

        public IActionResult Index()
        {
            var data = _employeeRepository.GetAll();
            var department = _departmentRepository.GetAll();

            foreach (var item in data)
            {
                item.departName = department.Where(x => x.ComId == item.ComId).Select(a => a.DeptName).FirstOrDefault();
            }

            var designation = _designationRepository.GetAll();

            foreach (var item in data)
            {
                item.DesigName= designation.Where(x => x.ComId == item.ComId).Select(a => a.DesigName).FirstOrDefault();
            }
            var shift = _shiftRepository.GetAll();

            foreach (var item in data)
            {
                item.ShiftName = shift.Where(x => x.ComId == item.ComId).Select(a => a.ShiftName).FirstOrDefault();
            }

            var company = _companyRepository.GetAll();

            foreach (var item in data)
            {
                item.Compname = company.Where(x => x.ComId == item.ComId).Select(a => a.ComName).FirstOrDefault();
            }
            //var employee = _employeeRepository.GetAll();

            //foreach (var item in data)
            //{
            //    item.Empname = employee.Where(x => x.ComId == item.ComId).Select(a => a.EmpName).FirstOrDefault();
            //}

          
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
            ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
            ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
            return View();
        }
        [HttpPost]
      

        public IActionResult Create(Employee model, Company mod)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
            ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
            ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
            var company = _companyRepository.GetById(mod.ComId);

         

            var data = new Employee()
            {
                ComId = model.ComId,
                EmpId = model.EmpId,
                DeptId = model.DeptId,
                EmpName = model.EmpName,
            
                EmpCode = model.EmpCode,
                Gender=model.Gender,
                ShiftId = model.ShiftId,
              
                DesigId = model.DesigId,
                Gross = model.Gross,
                dtJoin=model.dtJoin
            };

            if (model.Gross > 10000)
            {
                //var company = _companyRepository.GetById(mod.ComId);
                data.Basic = (model.Gross * 50) / 100;
                data.HRent = (model.Gross * 30) / 100;
                data.Medical = (model.Gross * 15) / 100;
                data.Others = (model.Gross - (data.Basic + data.HRent + data.Medical));
            }

            _employeeRepository.Add(data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
            ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
            ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
            var data = _employeeRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Employee model,Company mod)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
            ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
            ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
            var data = _employeeRepository.GetById(model.EmpId);
            var company = _companyRepository.GetById(mod.ComId);



            data.ComId = model.ComId;
            
            data.EmpName = model.EmpName;

            data.EmpCode = model.EmpCode;
            data.Gender = model.Gender;
            data.DeptId = model.DeptId;
            data.DesigId = model.DesigId;
            data.ShiftId=model.ShiftId;
            data.Gross=model.Gross; 
            if (model.Gross > 10000)
            {
                //var company = _companyRepository.GetById(mod.ComId);
                data.Basic = ( model.Gross * 50)/100;
                data.HRent =(  model.Gross * 30) /100;
                //data.Medical =( company.Medical * model.Gross * 15) /100;
                data.Medical = (model.Gross * 10) / 100;
                data.Others = (model.Gross - (data.Basic + data.HRent + data.Medical));
            }
            data.dtJoin = model.dtJoin;

            _employeeRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }
        ////public IActionResult Detalis(int id)
        ////{
        ////    var data = _employeeRepository.GetById(id);
        ////    return View(data);
        ////}
        public IActionResult Delete(int id)
        {
            var data = _employeeRepository.GetById(id);
            _employeeRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
