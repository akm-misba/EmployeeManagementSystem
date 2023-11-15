using Microsoft.AspNetCore.Mvc;
using MVC.API.Models;
using MVC.API.Repositories;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _companyRepository.GetAll();
            return Ok(data);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Create(Company model)
        {
            var data = new Company()
            {
                ComId = model.ComId,
                ComName = model.ComName,
                Basic = model.Basic,
                Hrent = model.Hrent,
                Medical = model.Medical,
                IsInactive = model.IsInactive


            };
            _companyRepository.Add(data);
            return Ok(data);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Company model )
        {
            var data = _companyRepository.GetById(model.ComId);
            data.ComName = model.ComName;
            data.Basic = model.Basic;
            data.Hrent = model.Hrent;
            data.Medical = model.Medical;
            data.IsInactive = model.IsInactive;

            _companyRepository.Update(data);
            return Ok(model);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _companyRepository.GetById(id);
            _companyRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
