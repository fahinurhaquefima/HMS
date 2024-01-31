using HMS.WebApp.DatabaseContest;
using HMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS.WebApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContest _dbContest;

        public DoctorController(ApplicationDbContest dbContest)
        {
            _dbContest = dbContest;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _dbContest.Set<Doctor>().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Doctor());
            }
            else
            {
                var data = await _dbContest.Set<Doctor>().FindAsync(id);
                return View(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id,Doctor doctor)
        {
            if(id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _dbContest.Set<Doctor>().AddAsync(doctor);
                    await _dbContest.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            //Update
            else
            {
                if (ModelState.IsValid)
                {
                    _dbContest.Set<Doctor>().Update(doctor);
                    _dbContest.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(new Doctor());
        }
    }
}
