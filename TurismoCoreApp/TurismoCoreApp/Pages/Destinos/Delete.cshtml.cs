using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.Destinos
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public DeleteModel(TurismoCoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destino Destino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos.FirstOrDefaultAsync(m => m.Id == id);

            if (destino == null)
            {
                return NotFound();
            }
            else
            {
                Destino = destino;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos.FindAsync(id);
            if (destino != null)
            {
                Destino = destino;
                _context.Destinos.Remove(Destino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
