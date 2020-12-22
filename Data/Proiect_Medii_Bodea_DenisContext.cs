using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Bodea_Denis.Models;

namespace Proiect_Medii_Bodea_Denis.Data
{
    public class Proiect_Medii_Bodea_DenisContext : DbContext
    {
        public Proiect_Medii_Bodea_DenisContext (DbContextOptions<Proiect_Medii_Bodea_DenisContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Medii_Bodea_Denis.Models.Masina> Masina { get; set; }

        public DbSet<Proiect_Medii_Bodea_Denis.Models.Angajat> Angajat { get; set; }

        public DbSet<Proiect_Medii_Bodea_Denis.Models.Tara> Tara { get; set; }

        public DbSet<Proiect_Medii_Bodea_Denis.Models.Category> Category { get; set; }
    }
}
