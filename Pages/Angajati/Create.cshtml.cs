﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_Bodea_Denis.Data;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Pages.Angajati
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public CreateModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}