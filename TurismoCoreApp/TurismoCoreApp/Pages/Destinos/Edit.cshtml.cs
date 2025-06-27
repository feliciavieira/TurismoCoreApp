using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.Destinos
{
    public class EditModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public EditModel(TurismoCoreApp.Data.ApplicationDbContext context)
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

            var destino =  await _context.Destinos.FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }
            Destino = destino;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Destino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoExists(Destino.Id))
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

        private bool DestinoExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }
    }
}
