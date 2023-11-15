using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.API.Models;
using MVC.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly ICompanyRepository _companyRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository )
        {
            _attendanceRepository = attendanceRepository;
            //_employeeRepository = employeeRepository;
            //_companyRepository = companyRepository;


        }
        // GET: api/<AttendanceController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _attendanceRepository.GetAll();
            return Ok(data);
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public IActionResult Create(Attendance model)
        {

            //ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            //ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");



            var data = new Attendance()
            {
                ComId = model.ComId,
                EmpId = model.EmpId,
                dtDate = model.dtDate,
                TimeIn = model.TimeIn,
                TimeOut = model.TimeOut

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


        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Attendance model)
        {

            //ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            //ViewBag.employee = new SelectList(_employeeRepository.GetAll(), "EmpId", "EmpName");
            var data = _attendanceRepository.GetById(model.AttdId);

            data.ComId = model.ComId;
            data.EmpId = model.EmpId;
            data.dtDate = model.dtDate;
            data.TimeIn = model.TimeIn;
            data.TimeOut = model.TimeOut;

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
            return Ok(data);
        }


        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
