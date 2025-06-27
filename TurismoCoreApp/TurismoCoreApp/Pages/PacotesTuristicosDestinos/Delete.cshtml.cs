using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.PacotesTuristicosDestinos
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public DeleteModel(TurismoCoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristicoDestino PacoteTuristicoDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturisticodestino = await _context.PacoteTuristicoDestinos.FirstOrDefaultAsync(m => m.PacoteTuristicoId == id);

            if (pacoteturisticodestino == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristicoDestino = pacoteturisticodestino;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturisticodestino = await _context.PacoteTuristicoDestinos.FindAsync(id);
            if (pacoteturisticodestino != null)
            {
                PacoteTuristicoDestino = pacoteturisticodestino;
                _context.PacoteTuristicoDestinos.Remove(PacoteTuristicoDestino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
