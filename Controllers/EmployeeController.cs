using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasksberbank.DbContexts;
using tasksberbank.Models;

namespace tasksberbank.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _db;

        public EmployeeController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Employees.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    request.CreateDate = DateTime.Now;
                    await _db.AddAsync(request);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Не удалось сохранить изменения" +
                    "Попробуйте еще раз, и если проблема не устранится " +
                    "обратитесь к своему системному администратору.");
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = await _db.Employees.FindAsync(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee empobj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(empobj);
                await _db.SaveChangesAsync();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = await _db.Employees.FindAsync(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
