using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppWeb.Data;
using MiPrimerAppWeb.Data.Entities;
using MiPrimerAppWeb.DTOs;

namespace MiPrimerAppWeb.Controllers
{
    public class LoansController : Controller
    {
        private readonly SchoolContext _context;
        private readonly IMapper mapper;

        public LoansController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {

            
            var data = await _context.Loans.Include(l => l.Book).Include(l => l.Student).ToListAsync();
            var list = data.Select(x => mapper.Map<LoanDTO>(x)).ToList();
            return View(list);
            //var schoolContext = _context.Loans.Include(l => l.Book).Include(l => l.Student);
            //return View(await schoolContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.LoanID == id);
            if (loan == null)
            {
                return NotFound();
            }
            var loanDTO = mapper.Map<LoanDTO>(loan);
            return View(loanDTO);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanID,BookID,StudentID,DateLoan")] LoanDTO loanDTO)
        {
            if (ModelState.IsValid)
            {
                var loan = mapper.Map<Loan>(loanDTO);
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", loanDTO.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", loanDTO.StudentID);
            return View(loanDTO);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", loan.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", loan.StudentID);
            var loanDTO = mapper.Map<LoanDTO>(loan);
            return View(loanDTO);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanID,BookID,StudentID,DateLoan")] LoanDTO loanDTO)
        {
            if (id != loanDTO.LoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loan = mapper.Map<Loan>(loanDTO);
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loanDTO.LoanID))
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
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", loanDTO.BookID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", loanDTO.StudentID);
            return View(loanDTO);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.LoanID == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanID == id);
        }
    }
}
