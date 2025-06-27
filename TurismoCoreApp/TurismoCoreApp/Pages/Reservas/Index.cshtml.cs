using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoCoreApp.Data;
using TurismoCoreApp.Models;

namespace TurismoCoreApp.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly TurismoCoreApp.Data.ApplicationDbContext _context;

        public IndexModel(TurismoCoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reserva { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico).ToListAsync();
        }
    }
}
