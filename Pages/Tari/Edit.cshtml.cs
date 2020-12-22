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

namespace Proiect_Medii_Bodea_Denis.Pages.Tari
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public EditModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tara Tara { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tara = await _context.Tara.FirstOrDefaultAsync(m => m.ID == id);

            if (Tara == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaraExists(Tara.ID))
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

        private bool TaraExists(int id)
        {
            return _context.Tara.Any(e => e.ID == id);
        }
    }
}
