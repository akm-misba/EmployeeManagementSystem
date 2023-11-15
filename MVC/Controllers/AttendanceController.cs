using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            _attendanceRepository = attendanceRepository;
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;


        }


        public IActionResult Index()
        {
            var data = _attendanceRepository.GetAll();
            var company = _companyRepository.GetAll();

            foreach (var item in data)
            {
                item.Compname = company.Where(x => x.ComId == item.ComId).Select(a => a.ComName).FirstOrDefault();
            }
            var employee = _employeeRepository.GetAll();

            foreach (var item in data)
            {
                item.Empname = employee.Where(x => x.ComId == item.ComId).Select(a => a.EmpName).FirstOrDefault();
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");
            return View();
        }
        [HttpPost]


        public IActionResult Create(Attendance model)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");



            var data = new Attendance()
            {
                ComId = model.ComId,
                EmpId = model.EmpId,
                dtDate = model.dtDate,
                TimeIn=model.TimeIn,
                TimeOut=model.TimeOut

            };



            if (model.TimeIn < new TimeSpan(9, 5, 0))
            {
                data.AttStatus = "P";

            }
            else if (model.TimeIn > new TimeSpan(9, 5, 0))
            {
                data.AttStatus = "L";

            }
            else
                data.AttStatus = "A";


            _attendanceRepository.Add(data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");
            var data = _attendanceRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Attendance model)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");
            var data = _attendanceRepository.GetById(model.AttdId);
            
            data.ComId = model.ComId;
            data.EmpId= model.EmpId;
            data.dtDate = model.dtDate;
            data.TimeIn = model.TimeIn; 
            data.TimeOut= model.TimeOut;

            if (model.TimeIn < new TimeSpan(9, 5, 0))
            {
                data.AttStatus = "P";

            }
            else if (model.TimeIn > new TimeSpan(9, 5, 0))
            {
                data.AttStatus = "L";

            }
            else
                data.AttStatus = "A"; ;

            _attendanceRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var data = _attendanceRepository.GetById(id);
            _attendanceRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
