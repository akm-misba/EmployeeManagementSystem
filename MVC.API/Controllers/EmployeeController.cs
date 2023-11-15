using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.API.Models;
using MVC.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IShiftRepository _shiftRepository;
        public EmployeeController(IEmployeeRepository employeeRepository , ICompanyRepository companyRepository, IDepartmentRepository departmentRepository, IDesignationRepository designationRepository, IShiftRepository shiftRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _shiftRepository = shiftRepository;
            _designationRepository = designationRepository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _employeeRepository.GetAll();
            return Ok(data);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            //ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            //ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
            //ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
            //ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
           // var company = _companyRepository.GetById(mod.ComId);



            var data = new Employee()
            {
                ComId = model.ComId,
                EmpId = model.EmpId,
                DeptId = model.DeptId,
                EmpName = model.EmpName,

                EmpCode = model.EmpCode,
                Gender = model.Gender,
                ShiftId = model.ShiftId,

                DesigId = model.DesigId,
                Gross = model.Gross,
                dtJoin = model.dtJoin
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
            return Ok(data);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Employee model)
        {
        //    ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
        //    ViewBag.department = new SelectList(_departmentRepository.GetAll(), "DeptId", "DeptName");
        //    ViewBag.designation = new SelectList(_designationRepository.GetAll(), "DesigId", "DesigName");
        //    ViewBag.shift = new SelectList(_shiftRepository.GetAll(), "ShiftId", "ShiftName");
            var data = _employeeRepository.GetById(model.EmpId);
            //var company = _companyRepository.GetById(mod.ComId);



            data.ComId = model.ComId;

            data.EmpName = model.EmpName;

            data.EmpCode = model.EmpCode;
            data.Gender = model.Gender;
            data.DeptId = model.DeptId;
            data.DesigId = model.DesigId;
            data.ShiftId = model.ShiftId;
            data.Gross = model.Gross;
            if (model.Gross > 10000)
            {
                //var company = _companyRepository.GetById(mod.ComId);
                data.Basic = (model.Gross * 50) / 100;
                data.HRent = (model.Gross * 30) / 100;
                //data.Medical =( company.Medical * model.Gross * 15) /100;
                data.Medical = (model.Gross * 10) / 100;
                data.Others = (model.Gross - (data.Basic + data.HRent + data.Medical));
            }
            data.dtJoin = model.dtJoin;

            _employeeRepository.Update(data);
            return Ok(data);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _employeeRepository.GetById(id);
            _employeeRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
