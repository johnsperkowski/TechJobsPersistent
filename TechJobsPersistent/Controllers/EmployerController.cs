using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel view = new AddEmployerViewModel();
            return View(view);
        }

        [HttpPost]
        [Route("/Employer/Add")]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployer)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployer.Name,
                    Location = addEmployer.Location
                };
                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            return View(addEmployer);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Single(e => e.Id == id);

            AddEmployerViewModel viewModel = new AddEmployerViewModel(employer);
            return View(viewModel);
        }
    }
}
