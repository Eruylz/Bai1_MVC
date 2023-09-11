using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai1.Models;

namespace Bai1.Controllers
{
    public class DaiLiesController : Controller
    {
        private readonly Bai1DbContext _context;

        public DaiLiesController(Bai1DbContext context)
        {
            _context = context;
        }

        // GET: DaiLies
        public async Task<IActionResult> Index()
        {
              return _context.DaiLy != null ? 
                          View(await _context.DaiLy.ToListAsync()) :
                          Problem("Entity set 'Bai1DbContext.DaiLy'  is null.");
        }

        // GET: DaiLies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DaiLy == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daiLy == null)
            {
                return NotFound();
            }

            return View(daiLy);
        }

        // GET: DaiLies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaiLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,MaHTPP")] DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daiLy);
        }

        // GET: DaiLies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DaiLy == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLy.FindAsync(id);
            if (daiLy == null)
            {
                return NotFound();
            }
            return View(daiLy);
        }

        // POST: DaiLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,MaHTPP")] DaiLy daiLy)
        {
            if (id != daiLy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daiLy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaiLyExists(daiLy.Id))
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
            return View(daiLy);
        }

        // GET: DaiLies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DaiLy == null)
            {
                return NotFound();
            }

            var daiLy = await _context.DaiLy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daiLy == null)
            {
                return NotFound();
            }

            return View(daiLy);
        }

        // POST: DaiLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DaiLy == null)
            {
                return Problem("Entity set 'Bai1DbContext.DaiLy'  is null.");
            }
            var daiLy = await _context.DaiLy.FindAsync(id);
            if (daiLy != null)
            {
                _context.DaiLy.Remove(daiLy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaiLyExists(int id)
        {
          return (_context.DaiLy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
