using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabManagement.Data;
using CabManagement.Models.ViewModel;
using CabManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace CabManagement.Areas.Drivers.Controllers
{
    [Area("Driver")]
    public class DriverViewModelsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DriverViewModelsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Driver/DriverViewModels
        public async Task<IActionResult> Index()
        {
            return View(await db.Bookings.ToListAsync());
        }

        // GET: Driver/DriverViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
                return View(await db.Drivers.ToListAsync());
            
            //if (id == null || db.DriverViewModel == null)   ,my edit

            //{
            //    return NotFound();
            //}

            //var driverViewModel = await db.Drivers
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (driverViewModel == null)
            //{
            //    return NotFound();
            //}

            //return View(driverViewModel);
        }

        //__________________________________________________

        //GET: Driver/DriverViewModels/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Driver/DriverViewModels/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,LicenseNo,PhoneNo,CarNo")] DriverViewModel driverViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(driverViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(driverViewModel);
        //}

        //_________________________________________________________________________________

        [HttpGet]
        public IActionResult Create( string Id)
        {
            ViewData["DriverId"] = new SelectList(db.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Drivers/Driver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverViewModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new Driver()
            {
                DriverId = id,
                LicenseNumber = model.LicenseNumber,
                CarName = model.CarName,
                CarNumber = model.CarNumber,


            };
            await db.AddAsync(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Login", "Home", new { Area = "Accounts" });
        }
    }
}


        // GET: Driver/DriverViewModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || db.DriverViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    var driverViewModel = await db.DriverViewModel.FindAsync(id);
        //    if (driverViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(driverViewModel);
        //}

        //// POST: Driver/DriverViewModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,LicenseNo,PhoneNo,CarNo")] DriverViewModel driverViewModel)
        //{
        //    if (id != driverViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.Update(driverViewModel);
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DriverViewModelExists(DriverViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(LoginViewModel));
        //    }
        //    return View(driverViewModel);
        //}
        

            
            


        // GET: Driver/DriverViewModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || db.DriverViewModel == null)
//            {
//                return NotFound();
//            }

//            var driverViewModel = await db.Drivers
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (driverViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(driverViewModel);
//        }

//        // POST: Driver/DriverViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.DriverViewModel == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.DriverViewModel'  is null.");
//            }
//            var driverViewModel = await db.DriverViewModel.FindAsync(id);
//            if (driverViewModel != null)
//            {
//                db.DriverViewModel.Remove(driverViewModel);
//            }
            
//            await db.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool DriverViewModelExists(int id)
//        {
//          return db.Drivers.Any(e => e.Id == id);
//        }
//    }
//}
