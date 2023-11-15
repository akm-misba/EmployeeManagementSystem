using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ICompanyRepository _companyRepository;
        public ShiftController(IShiftRepository shiftRepository, ICompanyRepository companyRepository)
        {
            _shiftRepository = shiftRepository;
            _companyRepository = companyRepository; 
        }

        public IActionResult Index()
        {
            var data = _shiftRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shift model)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = new Shift()
            {
                
                ComId = model.ComId,
                ShiftName = model.ShiftName,
                ShiftIn = model.ShiftIn,
                ShiftOut = model.ShiftOut,
                ShiftLate = model.ShiftLate


            };
            _shiftRepository.Add(data);
            return RedirectToAction(nameof(Index));




        }
        public IActionResult Edit(int id)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _shiftRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Shift model)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = _shiftRepository.GetById(model.ShiftId);
           
            data.ComId=model.ComId;
            data.ShiftName=model.ShiftName;
            data.ShiftIn=model.ShiftIn;
            data.ShiftOut=model.ShiftOut;
            data.ShiftLate=model.ShiftLate;

            _shiftRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = _shiftRepository.GetById(id);
            _shiftRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
