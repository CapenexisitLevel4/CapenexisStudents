using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners.Data;
using CapenexisLearners.Models;

namespace CapenexisLearners.Pages.Learners
{
    public class EditModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public EditModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Learner Learner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Learner == null)
            {
                return NotFound();
            }

            var learner =  await _context.Learner.FirstOrDefaultAsync(m => m.Id == id);
            if (learner == null)
            {
                return NotFound();
            }
            Learner = learner;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Learner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerExists(Learner.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LearnerExists(int id)
        {
          return (_context.Learner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
