using Ders54_Core_Empty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ders54_Core_Empty.Controllers
{
    public class HomeController : Controller
    {
        iakademi45Context context = new iakademi45Context();

        public async Task<IActionResult> Index()
        {
            var listele = await context.Students.ToListAsync();
            return View(listele);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string StudentNumber, [Bind("StudentName,Department,_Age,StudentNumber,Email,Password,PasswordAgain")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (!StudentNumberExists(student.StudentNumber))
                {
                    context.Add(student);
                    await context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        private bool StudentNumberExists(string StudentNumber)
        {
            return context.Students.Any(e => e.StudentNumber == StudentNumber);
        }


        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }

            var ogrenci = await context.Students.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        //POST/Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,Department,Age,StudentNumber")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            return View(student);
        }
        private bool StudentExists(int id)
        {
            return context.Students.Any(e => e.StudentID == id);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }

            var ogrenci = await context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        //POST/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Students == null)
            {
                return Problem("Entity set 'context.Students' is null.");
            }
            var ogrenci = await context.Students.FindAsync(id);
            if (ogrenci != null)
            {
                context.Students.Remove(ogrenci);
                await context.SaveChangesAsync();

            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }

            var ogrenci = await context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }
    }
}
