using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.API.Models;
using MVC.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Create(Department model)
        {
           var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

            var data = new Department()
            {

                ComId = model.ComId,

                DeptName = model.DeptName,



            };
            _departmentRepository.Add(data);
            return Ok(data);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Department model)
        {
            //var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _departmentRepository.GetById(model.DeptId);
            data.ComId = model.ComId;
            data.DeptName = model.DeptName;
            _departmentRepository.Update(data);
            return Ok(data);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _departmentRepository.GetById(id);
            _departmentRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
