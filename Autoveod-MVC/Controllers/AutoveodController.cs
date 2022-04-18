#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoveod_MVC.Data;
using Autoveod_MVC.Models;

namespace Autoveod_MVC.Controllers
{
    public class AutoveodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoveodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autoveod
        public async Task<IActionResult> KoikVeod()
        {
            return View(await _context.Autoveod.ToListAsync());
        }

        public async Task<IActionResult> JuhitaVeod()
        {
            var autovedu = _context.Autoveod
                .Where(m => m.JuhtEesnimi == null && m.JuhtPerenimi == null);
            if (autovedu == null)
            {
                return NotFound();
            }

            return View("JuhitaVeod", autovedu);
        }

        public async Task<IActionResult> LisaJuht(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autovedu = await _context.Autoveod.FindAsync(id);
            if (autovedu == null)
            {
                return NotFound();
            }
            return View(autovedu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LisaJuht(int id, [Bind("Id,Tellija,Alguspunkt,Lõpppunkt,KohalejoudmiseAeg,AutoNr,JuhtEesnimi,JuhtPerenimi,Valmis")] Autovedu autovedu)
        {
            if (id != autovedu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autovedu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoveduExists(autovedu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("JuhitaVeod");
            }
            return View(autovedu);
        }

        public IActionResult LopetamataVeod()
        {
            var autovedu = _context.Autoveod
                .Where(m => m.JuhtEesnimi != null && m.JuhtPerenimi != null && m.Valmis == false);
            if (autovedu == null)
            {
                return NotFound();
            }

            return View("LopetamataVeod", autovedu);
        }

        //Lopeta vedu
        public async Task<IActionResult> LopetaVedu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autovedu = await _context.Autoveod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autovedu == null)
            {
                return NotFound();
            }

            return View(autovedu);
        }

        [HttpPost, ActionName("LopetaVedu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LopetaVedu(int? id, [Bind("Id,Tellija,Alguspunkt,Lõpppunkt,KohalejoudmiseAeg,AutoNr,JuhtEesnimi,JuhtPerenimi,Valmis")] Autovedu autovedu)
        {
            if (id != autovedu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                autovedu.Valmis = true;
                try
                {
                    _context.Update(autovedu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoveduExists(autovedu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("LopetaVedu");
            }
            return View(autovedu);
        }

        // GET: Autoveod/Create
        public IActionResult Telli()
        {
            return View();
        }

        // POST: Autoveod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Telli([Bind("Id,Tellija,Alguspunkt,Lõpppunkt,KohalejoudmiseAeg,AutoNr,JuhtEesnimi,JuhtPerenimi,Valmis")] Autovedu autovedu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autovedu);
                await _context.SaveChangesAsync();
                return RedirectToAction("KoikVeod");
            }
            return View(autovedu);
        }

        // GET: Autoveod/Edit/5
        public async Task<IActionResult> Muuda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autovedu = await _context.Autoveod.FindAsync(id);
            if (autovedu == null)
            {
                return NotFound();
            }
            return View(autovedu);
        }

        // POST: Autoveod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Muuda(int id, [Bind("Id,Tellija,Alguspunkt,Lõpppunkt,KohalejoudmiseAeg,AutoNr,JuhtEesnimi,JuhtPerenimi,Valmis")] Autovedu autovedu)
        {
            if (id != autovedu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autovedu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoveduExists(autovedu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("KoikVeod");
            }
            return View(autovedu);
        }

        // GET: Autoveod/Delete/5
        public async Task<IActionResult> Kustuta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var autovedu = await _context.Autoveod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autovedu == null)
            {
                return NotFound();
            }

            return View(autovedu);
        }

        // POST: Autoveod/Delete/5
        [HttpPost, ActionName("Kustuta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KustutaConfirmed(int id)
        {
            var autovedu = await _context.Autoveod.FindAsync(id);
            _context.Autoveod.Remove(autovedu);
            await _context.SaveChangesAsync();
            return RedirectToAction("KoikVeod");
        }

        private bool AutoveduExists(int id)
        {
            return _context.Autoveod.Any(e => e.Id == id);
        }
    }
}
