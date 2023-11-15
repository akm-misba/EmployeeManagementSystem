using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVC.Models;
using MVC.Repositories;
using NuGet.Protocol.Core.Types;

namespace MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            var data=_companyRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company model)
        {
            if (ModelState.IsValid)
            {
             
                var data = new Company()
                {
                   ComId=model.ComId,
                   ComName=model.ComName,   
                   Basic=model.Basic,
                   Hrent=model.Hrent,   
                   Medical=model.Medical,
                   IsInactive=model.IsInactive
                    

                };
                _companyRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
            

        }
        public IActionResult Edit(int id)
        {
            var data=_companyRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Company model ,int id)
        {
            var data = _companyRepository.GetById(model.ComId);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (data == null)
            {
                return NotFound();
            }
            
            data.ComName = model.ComName;
            data.Basic = model.Basic;
            data.Hrent = model.Hrent;
            data.Medical = model.Medical;
            data.IsInactive = model.IsInactive;

            _companyRepository.Update(data);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalis( int id)
        {
            var data = _companyRepository.GetById(id);
            return View(data);
        }
        public IActionResult Delete (int id)
        {
            var data = _companyRepository.GetById(id);
            _companyRepository.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
   

       
}
