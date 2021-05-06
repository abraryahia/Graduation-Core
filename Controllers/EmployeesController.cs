using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Graduation_Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace Graduation_Core.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmployeesController : Controller
    {
        private readonly DMSContext _context;

        public EmployeesController(DMSContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrator")]

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var dMSContext = _context.Employee.Include(e => e.EmpC).Include(e => e.EmpL);
            List<Locations> LsLocations = new List<Locations>();
            LsLocations = _context.Locations.ToList();
            var Lsl = LsLocations
                              .Select(s => new
                              {
                                  Text = s.LFrom + " ===> " + s.LTo,
                                  Value = s.LId
                              })
                              .ToList();
            var cities = _context.City.ToList().Select(c => new CityModel() { ID = c.CId, Name = c.CName }).ToList();
            cities.Insert(0, new CityModel() { ID = 0, Name = "==== Select City ====" });
            ViewData["cities"] = new SelectList(cities, "ID", "Name");
            ViewData["locs"] = new SelectList(Lsl, "Value", "Text");
            return View(await dMSContext.ToListAsync());
        }

        [Authorize(Roles = "Administrator")]
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.EmpC)
                .Include(e => e.EmpL)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["EmpCId"] = new SelectList(_context.City, "CId", "CName");
            ViewData["EmpLId"] = new SelectList(_context.Locations, "LId", "LTo");
            return View();
        }
        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,EmpMobile,EmpEmail,EmpAddress,EmpSsn,EmpCId,EmpAddressDetails,EmpLId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpCId"] = new SelectList(_context.City, "CId", "DayOfTravel", employee.EmpCId);
            ViewData["EmpLId"] = new SelectList(_context.Locations, "LId", "LFrom", employee.EmpLId);
            return View(employee);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["EmpCId"] = new SelectList(_context.City, "CId", "CName", employee.EmpCId);
            ViewData["EmpLId"] = new SelectList(_context.Locations, "LId", "LTo", employee.EmpLId);
            return View(employee);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("EmpId,EmpName,EmpMobile,EmpEmail,EmpAddress,EmpSsn,EmpCId,EmpAddressDetails,EmpLId")] Employee employee)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
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
            ViewData["EmpCId"] = new SelectList(_context.City, "CId", "DayOfTravel", employee.EmpCId);
            ViewData["EmpLId"] = new SelectList(_context.Locations, "LId", "LFrom", employee.EmpLId);
            return View(employee);
        }
        [Authorize(Roles = "Administrator")]

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.EmpC)
                .Include(e => e.EmpL)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // POST: Employees/Delete/5
    [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long EmpId)
        {
            var employee = await _context.Employee.FindAsync(EmpId);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Administrator")]

        public JsonResult getlocationsbyid(int id)
        {
            List<Locations> LsLocations = new List<Locations>();
            LsLocations = _context.Locations.Where(a => a.CId == id).ToList();
            var Lsl = LsLocations
                              .Select(s => new
                              {
                                  Text = s.LFrom + " ===> " + s.LTo,
                                  Value = s.LId
                              })
                              .ToList();
            return Json(new SelectList(Lsl, "Value", "Text"));

        }
        [Authorize(Roles = "Administrator")]

        public IActionResult EmployeePackages(long id)
        {
            if (!EmployeeExists(id))
                return NoContent();
            var employee = _context.Employee.FirstOrDefault(emp => emp.EmpId == id);
            ViewBag.emp = employee;
            var packages = _context.PackagesInfo.ToList().Where(pid => pid.PLId == employee.EmpLId).OrderBy(d => d.Deleverydate);
            return View(packages);
        }
        [Authorize(Roles = "Administrator")]

        public ActionResult GetSender(long id)
        {
            if (id == 0)
                return NotFound();
            var sender = _context.SenderInfo.FirstOrDefault(s => s.SId == id);
            return View(sender);
        }
        [Authorize(Roles = "Administrator")]

        public ActionResult GetReciver(long id)
        {
            if (id == 0)
                return NotFound();
            var reciver = _context.ReceiverInfo.FirstOrDefault(r => r.RId == id);
            return View(reciver);
        }
        [Authorize(Roles = "Administrator")]

        private bool EmployeeExists(long id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
