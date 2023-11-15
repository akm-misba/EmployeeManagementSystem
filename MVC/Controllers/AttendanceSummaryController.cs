using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repositories;
using NuGet.Protocol.Plugins;
using System;
using System.Data;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MVC.Controllers
{
    public class AttendanceSummaryController : Controller
    {
        private readonly IAttendanceSummaryRepository _attendanceSummaryRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AttendanceSummaryController(IAttendanceSummaryRepository attendanceSummaryRepository, IAttendanceRepository attendanceRepository, ICompanyRepository companyRepository,IEmployeeRepository employeeRepository)
        {
            _attendanceSummaryRepository = attendanceSummaryRepository;
            _attendanceRepository = attendanceRepository;
            _companyRepository = companyRepository;
            _employeeRepository= employeeRepository;

        }
        
        public IActionResult Process()
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

          


            return View();
        }
        public IActionResult List(int comid,int month,int year)
        {
        //    var data = _attendanceSummaryRepository.GetAttendanceSummaryListByCompanyId(comid, month, year);
        //    var company = _companyRepository.GetAll();

        //    foreach (var item in data)
        //    {
        //        item.Compname = company.Where(x => x.ComId == item.ComId).Select(a => a.ComName).FirstOrDefault();
        //    }
        //    var employee = _employeeRepository.GetAll();

        //    foreach (var item in data)
        //    {
        //        item.Empname = employee.Where(x => x.ComId == item.ComId).Select(a => a.EmpName).FirstOrDefault();
        //    }

            var data = _attendanceSummaryRepository.GetAttendanceSummaryListByCompanyId(comid,month,year);


        
            return View(data);

        }
        [HttpPost]
        public IActionResult Process(string ComId,DateOnly dateTime)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

            var month = dateTime.Month;
            var year = dateTime.Year;
         
            
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-234E1GE\\misba;Database=MvcGtr2200;User Id=MvcGtr;Password=123456;Trusted_Connection=True;encrypt=false;TrustServerCertificate=true;"))
            {
                using (SqlCommand command = new SqlCommand($"exec AttendanceSummariesReport {ComId},{month},{year}", connection))
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
            return RedirectToAction(nameof(List),new { comid = ComId , month = dateTime.Month, year= dateTime.Year });
            
        }

    

      
        
     
    }
}
