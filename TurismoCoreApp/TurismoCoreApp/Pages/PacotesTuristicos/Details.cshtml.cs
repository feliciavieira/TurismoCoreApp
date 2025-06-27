using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.PacotesTuristicos
{
    public class DetailsModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public DetailsModel(TurismoCoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FirstOrDefaultAsync(m => m.Id == id);
            if (pacoteturistico == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristico = pacoteturistico;
            }
            return Page();
        }
    }
}
