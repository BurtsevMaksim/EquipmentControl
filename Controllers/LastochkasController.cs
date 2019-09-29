using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquipmentControl.Data;
using EquipmentControl.Models;

namespace EquipmentControl.Controllers
{
    public class LastochkasController : Controller
    {
        private readonly LastochkaContext _context;

        public LastochkasController(LastochkaContext context)
        {
            _context = context;
        }

        // GET: Lastochkas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lastochka.ToListAsync());
        }

        // GET: Lastochkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastochka = await _context.Lastochka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lastochka == null)
            {
                return NotFound();
            }

            return View(lastochka);
        }

        // GET: Lastochkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lastochkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainNumber,MarIP")] Lastochka lastochka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lastochka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lastochka);
        }

        // GET: Lastochkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastochka = await _context.Lastochka.FindAsync(id);
            if (lastochka == null)
            {
                return NotFound();
            }
            return View(lastochka);
        }

        // POST: Lastochkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainNumber,MarIP")] Lastochka lastochka)
        {
            if (id != lastochka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastochka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastochkaExists(lastochka.Id))
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
            return View(lastochka);
        }

        // GET: Lastochkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastochka = await _context.Lastochka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lastochka == null)
            {
                return NotFound();
            }

            return View(lastochka);
        }

        // POST: Lastochkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lastochka = await _context.Lastochka.FindAsync(id);
            _context.Lastochka.Remove(lastochka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastochkaExists(int id)
        {
            return _context.Lastochka.Any(e => e.Id == id);
        }
    }
}
