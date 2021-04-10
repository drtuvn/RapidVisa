using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Boundless.Data;
using Boundless.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Boundless.Controllers
{
    [Authorize]
    public class TimeSheetDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheetDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeSheetDetail.ToListAsync());
        }

        // GET: TimeSheetDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetDetail = await _context.TimeSheetDetail
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheetDetail == null)
            {
                return NotFound();
            }

            return View(timeSheetDetail);
        }
        private void PopulateTasksDownDown(object selectedTask = null)
        {
            IOrderedQueryable<TaskMaster> taskQuery;
            taskQuery = from p in _context.Task
                            orderby p.Name
                            select p;
            
            ViewBag.TaskID = new SelectList(taskQuery, "TaskID", "Name", selectedTask);
        }
        private void PopulateProjectsDownDown(object selectedProject = null)
        {
            var projectQuery = from p in _context.Project orderby p.ProjectName select p;
            ViewBag.ProjectID = new SelectList(projectQuery, "ProjectID", "ProjectName", selectedProject);
        }
        // GET: TimeSheetDetail/Create
        public IActionResult Create()
        {
            PopulateProjectsDownDown();
            PopulateTasksDownDown();
            return View();
        }

        // POST: TimeSheetDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSheetID,DaysofWeek,Hours,Period,ProjectID,UserID,TaskID,CreatedOn,TimeSheetMasterID")] TimeSheetDetail timeSheetDetail)
        {
            if (ModelState.IsValid)
            {
                Random rd = new Random();
                var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                timeSheetDetail.UserID = User.Identity.Name;
                timeSheetDetail.TimeSheetMasterID = rd.Next(1, 9999);
                _context.Add(timeSheetDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateProjectsDownDown(timeSheetDetail.ProjectID);
            PopulateTasksDownDown(timeSheetDetail.TaskID);
            return View(timeSheetDetail);
        }

        // GET: TimeSheetDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetDetail = await _context.TimeSheetDetail.FindAsync(id);
            if (timeSheetDetail == null)
            {
                return NotFound();
            }
            PopulateProjectsDownDown(timeSheetDetail.ProjectID);
            PopulateTasksDownDown(timeSheetDetail.TaskID);
            return View(timeSheetDetail);
        }

        // POST: TimeSheetDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSheetID,DaysofWeek,Hours,Period,ProjectID,UserID,TaskID,CreatedOn,TimeSheetMasterID")] TimeSheetDetail timeSheetDetail)
        {
            if (id != timeSheetDetail.TimeSheetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var toupdate = _context.TimeSheetDetail.Find(id);
                    //TryUpdateModelAsync(toupdate, "", new string[] { "","" });
                    _context.Update(timeSheetDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetDetailExists(timeSheetDetail.TimeSheetID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheetDetail);
        }

        // GET: TimeSheetDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetDetail = await _context.TimeSheetDetail
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheetDetail == null)
            {
                return NotFound();
            }

            return View(timeSheetDetail);
        }

        // POST: TimeSheetDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeSheetDetail = await _context.TimeSheetDetail.FindAsync(id);
            _context.TimeSheetDetail.Remove(timeSheetDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetDetailExists(int id)
        {
            return _context.TimeSheetDetail.Any(e => e.TimeSheetID == id);
        }
    }
}
