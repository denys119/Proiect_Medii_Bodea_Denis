using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_Bodea_Denis.Data;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Pages.Masini
{
    public class CreateModel : MasinaCategoriesPageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public CreateModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID", "TaraProvenienta");
            var masina = new Masina();
            masina.MasinaCategories = new List<MasinaCategory>();
            PopulateAssignedCategoryData(_context, masina);
            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMasina = new Masina();
            if(selectedCategories != null)
            {
                newMasina.MasinaCategories = new List<MasinaCategory>();
                foreach(var cat in selectedCategories)
                {
                    var catToAdd = new MasinaCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMasina.MasinaCategories.Add(catToAdd);
                }
            }

            if(await TryUpdateModelAsync<Masina>(
                newMasina,
                "Masina",
                i => i.Marca, i => i.Model, i => i.Pret, i => i.DataAdaugare, i => i.AngajatID))
            {
                _context.Masina.Add(newMasina);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMasina);
            return Page();
        }
    }
}
