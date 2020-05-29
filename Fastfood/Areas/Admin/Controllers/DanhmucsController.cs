using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fastfood.Models;

namespace Fastfood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhmucsController : Controller
    {
        private readonly FastfoodContext _context;

        public DanhmucsController(FastfoodContext context)
        {
            _context = context;
        }

        // GET: Admin/Danhmucs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Danhmuc.ToListAsync());
        }

        // GET: Admin/Danhmucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.DanhmucId == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenDanhmuc,DanhmucId")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenDanhmuc,DanhmucId")] Danhmuc danhmuc)
        {
            if (id != danhmuc.DanhmucId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.DanhmucId))
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
            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.DanhmucId == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // POST: Admin/Danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmuc = await _context.Danhmuc.FindAsync(id);
            _context.Danhmuc.Remove(danhmuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucExists(int id)
        {
            return _context.Danhmuc.Any(e => e.DanhmucId == id);
        }
    }
}
