using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly ICompanyRepository _companyRepository;

        public DesignationController(IDesignationRepository designationRepository,ICompanyRepository companyRepository)
        {
            _designationRepository = designationRepository;
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {

            var data = _designationRepository.GetAll();
            var company = _companyRepository.GetAll();

            foreach (var item in data)
            {
                item.Compname = company.Where(x => x.ComId == item.ComId).Select(a => a.ComName).FirstOrDefault();
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {


            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Designation model)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            var data = new Designation()
            {
                DesigId=model.DesigId,
                ComId = model.ComId,

                DesigName = model.DesigName



            };
            _designationRepository.Add(data);
            return RedirectToAction(nameof(Index));




        }
        public IActionResult Edit(int id)
        {

            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            return View();
            var data = _designationRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Designation model)
        {
            ViewBag.company = new SelectList(_companyRepository.GetAll(), "ComId", "ComName");
            
            var data = _designationRepository.GetById(model.DesigId);
            data.ComId = model.ComId;
            data.DesigName = model.DesigName;

            _designationRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = _designationRepository.GetById(id);
            _designationRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
