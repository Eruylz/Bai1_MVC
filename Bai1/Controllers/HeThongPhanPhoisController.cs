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
    public class HeThongPhanPhoisController : Controller
    {
        private readonly Bai1DbContext _context;

        public HeThongPhanPhoisController(Bai1DbContext context)
        {
            _context = context;
        }

        // GET: HeThongPhanPhois
        public async Task<IActionResult> Index()
        {
              return _context.HeThongPhanPhoi != null ? 
                          View(await _context.HeThongPhanPhoi.ToListAsync()) :
                          Problem("Entity set 'Bai1DbContext.HeThongPhanPhoi'  is null.");
        }

        // GET: HeThongPhanPhois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeThongPhanPhois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heThongPhanPhoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }
            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (id != heThongPhanPhoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heThongPhanPhoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeThongPhanPhoiExists(heThongPhanPhoi.Id))
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
            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }

            var heThongPhanPhoi = await _context.HeThongPhanPhoi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HeThongPhanPhoi == null)
            {
                return Problem("Entity set 'Bai1DbContext.HeThongPhanPhoi'  is null.");
            }
            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);
            if (heThongPhanPhoi != null)
            {
                _context.HeThongPhanPhoi.Remove(heThongPhanPhoi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeThongPhanPhoiExists(int id)
        {
          return (_context.HeThongPhanPhoi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
