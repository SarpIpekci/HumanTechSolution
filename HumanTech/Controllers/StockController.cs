using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumanTech.Models;

namespace HumanTech.Controllers
{
    public class StockController : Controller
    {
        private readonly StockDbContext _context;

        public StockController(StockDbContext context)
        {
            _context = context;
        }

        // GET: Stock
        public async Task<IActionResult> Index()
        {
            return _context.Stocks != null ?
                        View(await _context.Stocks.ToListAsync()) :
                        Problem("Entity set 'StockDbContext.Stocks'  is null.");
        }

        // GET: Stock/AddOrEdit
        //Update and Insert combine.
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Stock());
            else
                return View(_context.Stocks.Find(id));
        }

        // POST: Stock/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("StockID,StockName,Quantity,UnitPrice,IsActive,CreatedDate")] Stock stock)
        {
            //Validation control
            if (ModelState.IsValid)
            {
                //Check id is exist
                //If exist intert
                if (stock.StockID == 0)
                {
                    stock.IsActive = true;
                    stock.CreatedDate = DateTime.Now;
                    _context.Add(stock);
                }
                //If not exist update
                else
                    _context.Update(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stocks == null)
            {
                return Problem("Entity set 'StockDbContext.Stocks'  is null.");
            }
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
