using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class MasinaData
    {
        public IEnumerable<Masina> Masina { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MasinaCategory> MasinaCategories { get; set; }
    }
}
