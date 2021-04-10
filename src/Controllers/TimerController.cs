using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Boundless.Models;
using Boundless.Data;
using Boundless.ViewModels;

namespace Boundless.Controllers
{
    public class TimerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Timer
        public ActionResult Index(int? id)
        {
            var vm = new TimeSheetData();
            vm.Projects = _context.Project.OrderBy(i => i.ProjectName);
            vm.Users = _context.Users.OrderBy(i => i.Email);
            vm.Customers = _context.Customer.OrderBy(c => c.Company);
            if (id != null)
            {
                ViewBag.UserID = id.Value;
            }
            return View(vm);
        }

        // GET: Timer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Timer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Timer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Timer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Timer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Timer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}