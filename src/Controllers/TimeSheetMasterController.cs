using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Boundless.Data;
using Boundless.Models;
using Boundless.ViewModels;

namespace Boundless.Controllers
{
    public class TimeSheetMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheetMaster
        public async Task<IActionResult> Index(string id)
        {
            
            if (!string.IsNullOrEmpty(id))
            {
                return View(await _context.TimeSheetMaster.Where(t => t.UserID == id).ToListAsync());
            }
            else
                return View(await _context.TimeSheetMaster.ToListAsync());
        }

        // GET: TimeSheetMaster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetMaster = await _context.TimeSheetMaster
                .FirstOrDefaultAsync(m => m.TimeSheetMasterID == id);
            if (timeSheetMaster == null)
            {
                return NotFound();
            }

            return View(timeSheetMaster);
        }

        // GET: TimeSheetMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeSheetMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSheetMasterID,FromDate,ToDate,TotalHours,UserID,CreatedOn,TimeSheetStatus,Comment")] TimeSheetMaster timeSheetMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSheetMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheetMaster);
        }

        // GET: TimeSheetMaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetMaster = await _context.TimeSheetMaster.FindAsync(id);
            if (timeSheetMaster == null)
            {
                return NotFound();
            }
            return View(timeSheetMaster);
        }

        // POST: TimeSheetMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSheetMasterID,FromDate,ToDate,TotalHours,UserID,CreatedOn,TimeSheetStatus,Comment")] TimeSheetMaster timeSheetMaster)
        {
            if (id != timeSheetMaster.TimeSheetMasterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheetMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetMasterExists(timeSheetMaster.TimeSheetMasterID))
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
            return View(timeSheetMaster);
        }

        // GET: TimeSheetMaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSheetMaster = await _context.TimeSheetMaster
                .FirstOrDefaultAsync(m => m.TimeSheetMasterID == id);
            if (timeSheetMaster == null)
            {
                return NotFound();
            }

            return View(timeSheetMaster);
        }

        // POST: TimeSheetMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeSheetMaster = await _context.TimeSheetMaster.FindAsync(id);
            _context.TimeSheetMaster.Remove(timeSheetMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetMasterExists(int id)
        {
            return _context.TimeSheetMaster.Any(e => e.TimeSheetMasterID == id);
        }
    }
}
