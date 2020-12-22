using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Bodea_Denis.Data;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Pages.Masini
{
    public class EditModel : MasinaCategoriesPageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public EditModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Masina = await _context.Masina
                .Include(b => b.Angajat)
                .Include(b => b.MasinaCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Masina == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Masina);
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID", "TaraProvenienta");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var masinaToUpdate = await _context.Masina
                .Include(i => i.Angajat)
                .Include(i => i.MasinaCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if(masinaToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Masina>(
                masinaToUpdate,
                "Masina",
                i => i.Marca, i => i.Model, i => i.Pret, i => i.DataAdaugare, i => i.Angajat))
            {
                UpdateMasinaCategories(_context, selectedCategories, masinaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateMasinaCategories(_context, selectedCategories, masinaToUpdate);
            PopulateAssignedCategoryData(_context, masinaToUpdate);
            return Page();
        }

        private bool MasinaExists(int id)
        {
            return _context.Masina.Any(e => e.ID == id);
        }
    }
}
