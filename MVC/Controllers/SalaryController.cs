using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MVC.Repositories;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class SalaryController : Controller
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

        public IActionResult salaryData()
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");


            return View();
        }
        public IActionResult Index(int comid, string month, string year)

        {
            //var data = _salaryRepository.GetAttendanceSalaryListByCompanyId(comid, month, year);
            var data = _salaryRepository.GetAll();

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
        [HttpPost]
        public IActionResult salaryData(string ComId, DateOnly dateTime)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

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
            return RedirectToAction(nameof(Index));

        }
    }
}
