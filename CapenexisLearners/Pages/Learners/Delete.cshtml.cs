﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners.Data;
using CapenexisLearners.Models;

namespace CapenexisLearners.Pages.Learners
{
    public class DeleteModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public DeleteModel(CapenexisLearners.Data.CapenexisLearnersContext context)
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

            var learner = await _context.Learner.FirstOrDefaultAsync(m => m.Id == id);

            if (learner == null)
            {
                return NotFound();
            }
            else 
            {
                Learner = learner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Learner == null)
            {
                return NotFound();
            }
            var learner = await _context.Learner.FindAsync(id);

            if (learner != null)
            {
                Learner = learner;
                _context.Learner.Remove(Learner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
