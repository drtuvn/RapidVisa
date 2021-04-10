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
    public class AllTimeSheetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllTimeSheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllTimeSheet
        public async Task<IActionResult> Index(string option, string search, DateTime? from, DateTime? to)
        {
            if (to == null) to = DateTime.Now;
            if (from == null) from = to.Value.AddDays(-7);
            
            var timeSheetData = new TimeSheetData();
            IList<TimeSheetMasterView> allTimeSheet = new List<TimeSheetMasterView>();
            string userId = string.Empty;
            int? prjId = null;
            int pId;
            if (option == "user")
            {
                userId = search;
            }else
            {
                if(int.TryParse(search,out pId))
                {
                    prjId = pId;
                }
            }
            if (prjId ==null && string.IsNullOrEmpty(userId))
            {
                userId = User.Identity.Name;
            }
            
            Func<TimeSheetDetail, bool> predicate = null;

            if (String.IsNullOrWhiteSpace(userId) && prjId.HasValue) // projid is not null
            {
                predicate = i => (i.ProjectID == prjId.Value) && (i.CreatedOn > from.Value && i.Period < to.Value);
                
            }else if (!prjId.HasValue) //userid is not null
            {
                predicate = i => (i.UserID == userId) && (i.CreatedOn > from.Value && i.Period < to.Value);
            }
            else // both userid and projid not null
            {
                predicate = i => (i.ProjectID == prjId.Value && i.UserID == userId) && (i.CreatedOn > from.Value && i.Period < to.Value);
            }
            TimeSheetMasterView vm = new TimeSheetMasterView();
            var res = getTSMFromTSD(_context.TimeSheetDetail, predicate, out vm);
            var masterViewList = new List<TimeSheetMasterView>();
            if (res.Any()) masterViewList.Add(vm);
            timeSheetData.TimeSheetMasterView = masterViewList;
            timeSheetData.TimeSheetDetails = res;
            return View(timeSheetData);
            //return View(await _context.TimeSheetMaster.ToListAsync());
        }
        public IEnumerable<TimeSheetDetail> getTSMFromTSD(DbSet<TimeSheetDetail> ts, Func<TimeSheetDetail,bool>predicate, out TimeSheetMasterView vm)
        {
            IList<TimeSheetDetail> vms = new List<TimeSheetDetail>();
            vm = new TimeSheetMasterView();
            var min = ts.First().CreatedOn;
            var max = ts.First().Period;
            float sum = 0f;
            foreach (var detail in ts.Where(predicate))
            {
                min = min > detail.CreatedOn ? detail.CreatedOn : min;
                max = max < detail.Period ? detail.Period : max;
                sum += detail.Hours.Value;
                vms.Add(detail);
            }
            //vm.Username = _context.Users.Where(u => u.Id == vm.UserID).Select(u => u.UserName).FirstOrDefault();
            vm.FromDate = vm.CreatedOn = min.ToString();
            vm.ToDate = max.ToString();
            vm.TotalHours = sum;
            return vms;
        }
        private TimeSheetMasterView CreateTimeSheetVM(IGrouping<string, TimeSheetDetail> ts)
        {
            var vm = new TimeSheetMasterView();
            vm.UserID = ts.Key;
            var min = ts.First().CreatedOn;
            var max = ts.Last().Period;
            float sum = 0f;
            foreach (var detail in ts)
            {
                min = min > detail.CreatedOn ? detail.CreatedOn : min;
                max = max < detail.Period ? detail.Period : max;
                sum += detail.Hours.Value;
            }
            vm.Username = _context.Users.Where(u => u.Id == vm.UserID).Select(u => u.UserName).FirstOrDefault();
            vm.FromDate = vm.CreatedOn = min.ToString();
            vm.ToDate = max.ToString();
            return vm;
        }

        // GET: AllTimeSheet/Details/5
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

        

        private bool TimeSheetMasterExists(int id)
        {
            return _context.TimeSheetMaster.Any(e => e.TimeSheetMasterID == id);
        }
    }
}
