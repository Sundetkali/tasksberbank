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
    public class RequestController : Controller
    {
        private readonly ApplicationContext _db;

        public RequestController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Requests.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateRequests()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequests(Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    request.CreateDate = DateTime.Now;
                    _db.Add(request);
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

    }
}
