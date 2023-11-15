using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.API.Models;
using MVC.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly ICompanyRepository _companyRepository;

        public DesignationController(IDesignationRepository designationRepository, ICompanyRepository companyRepository)
        {
            _designationRepository = designationRepository;
            _companyRepository = companyRepository;
        }
        // GET: api/<DesignationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DesignationController>
        [HttpPost]
        public IActionResult Create(Designation model)
        {
            var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = new Designation()
            {
                DesigId = model.DesigId,
                ComId = model.ComId,

                DesigName = model.DesigName



            };
            _designationRepository.Add(data);
            return Ok(data);



        }

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Designation model)
        {
            var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");

            var data = _designationRepository.GetById(model.DesigId);
            data.ComId = model.ComId;
            data.DesigName = model.DesigName;

            _designationRepository.Update(data);
            return Ok(data);

        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _designationRepository.GetById(id);
            _designationRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
