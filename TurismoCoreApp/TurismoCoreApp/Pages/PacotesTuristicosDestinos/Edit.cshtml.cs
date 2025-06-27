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

namespace TurismoCoreApp.Pages.PacotesTuristicosDestinos
{
    public class EditModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public EditModel(TurismoCoreApp.Data.ApplicationDbContext context)
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

            var pacoteturisticodestino =  await _context.PacoteTuristicoDestinos.FirstOrDefaultAsync(m => m.PacoteTuristicoId == id);
            if (pacoteturisticodestino == null)
            {
                return NotFound();
            }
            PacoteTuristicoDestino = pacoteturisticodestino;
           ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Cidade");
           ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
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

            _context.Attach(PacoteTuristicoDestino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacoteTuristicoDestinoExists(PacoteTuristicoDestino.PacoteTuristicoId))
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

        private bool PacoteTuristicoDestinoExists(int id)
        {
            return _context.PacoteTuristicoDestinos.Any(e => e.PacoteTuristicoId == id);
        }
    }
}
