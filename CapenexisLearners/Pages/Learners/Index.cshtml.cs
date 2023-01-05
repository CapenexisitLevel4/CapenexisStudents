using System;
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
    public class IndexModel : PageModel
    {
        private readonly CapenexisLearners.Data.CapenexisLearnersContext _context;

        public IndexModel(CapenexisLearners.Data.CapenexisLearnersContext context)
        {
            _context = context;
        }

        public IList<Learner> Learner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Learner != null)
            {
                Learner = await _context.Learner.ToListAsync();
            }
        }
    }
}
