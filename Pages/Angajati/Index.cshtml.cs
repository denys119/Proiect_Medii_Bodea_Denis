﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Bodea_Denis.Data;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext _context;

        public IndexModel(Proiect_Medii_Bodea_Denis.Data.Proiect_Medii_Bodea_DenisContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }

        public async Task OnGetAsync()
        {
            Angajat = await _context.Angajat.ToListAsync();
        }
    }
}
