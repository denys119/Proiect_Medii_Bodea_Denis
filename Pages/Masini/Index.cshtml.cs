using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Bodea_Denis.Data;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Pages.Masini
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public IndexModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        public IList<Masina> Masina { get;set; }
        public MasinaData MasinaD { get; set; }
        public int MasinaID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            MasinaD = new MasinaData();
            MasinaD.Masina = await _context.Masina.Include(b=>b.Angajat)
                .Include(b => b.MasinaCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Pret)
                .ToListAsync();
            Masina = await _context.Masina.Include(b => b.Tara).ToListAsync();

            if( id != null)
            {
                MasinaID = id.Value;
                Masina masina = MasinaD.Masina
                    .Where(i => i.ID == id.Value).Single();
                MasinaD.Categories = masina.MasinaCategories.Select(s => s.Category);
            }
        }
    }
}
