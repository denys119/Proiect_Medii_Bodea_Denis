using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class MasinaCategory
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }

        public Masina Masina { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }
        }
}
