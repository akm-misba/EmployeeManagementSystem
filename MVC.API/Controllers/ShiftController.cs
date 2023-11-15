using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.API.Models;
using MVC.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ICompanyRepository _companyRepository;
        public ShiftController(IShiftRepository shiftRepository, ICompanyRepository companyRepository)
        {
            _shiftRepository = shiftRepository;
            _companyRepository = companyRepository;
        }
        // GET: api/<ShiftController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _shiftRepository.GetAll();
            return Ok(data);
        }
        // GET api/<ShiftController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShiftController>
        [HttpPost]
        public IActionResult Create(Shift model)
        {

            var  company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = new Shift()
            {

                ComId = model.ComId,
                ShiftName = model.ShiftName,
                ShiftIn = model.ShiftIn,
                ShiftOut = model.ShiftOut,
                ShiftLate = model.ShiftLate


            };
            _shiftRepository.Add(data);
            return Ok(data);

        }

        // PUT api/<ShiftController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(Shift model)
        {
            var company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _shiftRepository.GetById(model.ShiftId);

            data.ComId = model.ComId;
            data.ShiftName = model.ShiftName;
            data.ShiftIn = model.ShiftIn;
            data.ShiftOut = model.ShiftOut;
            data.ShiftLate = model.ShiftLate;

            _shiftRepository.Update(data);
            return Ok(data);
        }

        // DELETE api/<ShiftController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
