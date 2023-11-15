using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MVC.API.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public SalaryController(ISalaryRepository salaryRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;

            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }
        // GET: api/<SalaryController>
        [HttpGet]
        public IActionResult List(int comid, int month, int year)
        {
            var data = _salaryRepository.GetAttendanceSalaryListByCompanyId(comid, month, year);
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





            return Ok(data);

        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalaryController>
        [HttpPost]
        public IActionResult Process(int ComId, DateOnly dateTime)
        {
            var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            //var data = _attendanceSummaryRepository.GetAttendanceSummaryListByCompanyId(comid, month, year);

            var month = dateTime.Month;
            var year = dateTime.Year;


            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-234E1GE\\misba;Database=MvcGtr2200;User Id=MvcGtr;Password=123456;Trusted_Connection=True;encrypt=false;TrustServerCertificate=true;"))
            {
                using (SqlCommand command = new SqlCommand($"exec SalaryReport {ComId},{month},{year}", connection))
                {
                    try
                    {

                        connection.Open();

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }


            }

            // var data = _attendanceSummaryRepository.GetAll();
            return RedirectToAction(nameof(List), new { comid = ComId, month = dateTime.Month, year = dateTime.Year });

        }

        // PUT api/<SalaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
