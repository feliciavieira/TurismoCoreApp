using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.PacotesTuristicosDestinos
{
    public class CreateModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public CreateModel(TurismoCoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Cidade");
        ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
            return Page();
        }

        [BindProperty]
        public PacoteTuristicoDestino PacoteTuristicoDestino { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PacoteTuristicoDestinos.Add(PacoteTuristicoDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
