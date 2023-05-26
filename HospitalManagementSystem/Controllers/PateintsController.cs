using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Controllers;

namespace HospitalManagementSystem.Controllers
{
    public class PateintsController : Controller
    {
        private readonly DataContext _context;

        public PateintsController(DataContext context)
        {
            _context = context;
        }

        // GET: Pateints
        public async Task<IActionResult> Index()
        {
              return _context.Pateint != null ? 
                          View(await _context.Pateint.ToListAsync()) :
                          Problem("Entity set 'DataContext.Pateint'  is null.");
        }

        // GET: Pateints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pateint == null)
            {
                return NotFound();
            }

            var pateint = await _context.Pateint
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pateint == null)
            {
                return NotFound();
            }

            return View(pateint);
        }

        // GET: Pateints/Create
        public IActionResult Create()
        {
            return View("Home/AddPatient");
        }

        // POST: Pateints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,MatrialState,Address,Phone,Height,Weight")] Pateint pateint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pateint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Pateints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pateint == null)
            {
                return NotFound();
            }

            var pateint = await _context.Pateint.FindAsync(id);
            if (pateint == null)
            {
                return NotFound();
            }
            return View(pateint);
        }

        // POST: Pateints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,MatrialState,Address,Phone,Height,Weight")] Pateint pateint)
        {
            if (id != pateint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pateint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PateintExists(pateint.Id))
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
            return View(pateint);
        }

        // GET: Pateints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pateint == null)
            {
                return NotFound();
            }

            var pateint = await _context.Pateint
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pateint == null)
            {
                return NotFound();
            }

            return View(pateint);
        }

        // POST: Pateints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pateint == null)
            {
                return Problem("Entity set 'DataContext.Pateint'  is null.");
            }
            var pateint = await _context.Pateint.FindAsync(id);
            if (pateint != null)
            {
                _context.Pateint.Remove(pateint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PateintExists(int id)
        {
          return (_context.Pateint?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
