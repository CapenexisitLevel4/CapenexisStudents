using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapenexisLearners.Data;
using CapenexisLearners.Models;

namespace CapenexisLearners.Pages.Learners
{
    public class CreateModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public CreateModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Learner Learner { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Learner == null || Learner == null)
            {
                return Page();
            }

            _context.Learner.Add(Learner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
