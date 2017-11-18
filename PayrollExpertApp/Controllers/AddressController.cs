using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayrollExpertApp.Data;

namespace PayrollExpertApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly PayrollDbContext _context;

        public AddressController(PayrollDbContext context)
        {
            _context = context;
        }

        // GET: Address
        public async Task<IActionResult> Index()
        {
            var payrollDbContext = _context.Addresses.Include(a => a.Company).Include(a => a.Person);
            return View(await payrollDbContext.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.Company)
                .Include(a => a.Person)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Address/Create
        public IActionResult Create(string CId, string PId)
        {
            if (!string.IsNullOrEmpty(CId))
                ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", CId);
            if (!string.IsNullOrEmpty(PId))
                ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", PId);

            ViewData["AddressTypes"] = new SelectList(_context.DropdownList.Where(x => x.Type == "AddressType").ToList(), "Value", "Text");
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,CompanyId,Type,AddressLine1,AddressLine2,AddressLine3,City,Province,Country,PostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();

                if (address.CompanyId != null)
                    return RedirectToAction("Edit", "Company");

                if (address.PersonId != null)
                    return RedirectToAction("Edit", "People", address.PersonId);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", address.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", address.PersonId);
            ViewData["AddressTypes"] = new SelectList(_context.DropdownList.Where(x => x.Type == "AddressType").ToList(), "Value", "Text");
            return View(address);
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", address.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", address.PersonId);
            ViewData["AddressTypes"] = new SelectList(_context.DropdownList.Where(x => x.Type == "AddressType").ToList(), "Value", "Text");
            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,CompanyId,Type,AddressLine1,AddressLine2,AddressLine3,City,Province,Country,PostalCode")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (address.CompanyId != null)
                    return RedirectToAction("Edit", "Company");
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", address.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", address.PersonId);
            ViewData["AddressTypes"] = new SelectList(_context.DropdownList.Where(x => x.Type == "AddressType").ToList(), "Value", "Text");
            return View(address);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.Company)
                .Include(a => a.Person)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["AddressTypes"] = new SelectList(_context.DropdownList.Where(x => x.Type == "AddressType").ToList(), "Value", "Text");
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.Id == id);
            var companyId = address.CompanyId;
            var personId = address.PersonId;
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            
            if (companyId != null)
                return RedirectToAction("Edit", "Company");
            if (personId != null)
                return RedirectToAction("Edit", "People", personId);

            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
