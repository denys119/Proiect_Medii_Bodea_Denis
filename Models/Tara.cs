using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class Tara
    {
        public int ID { get; set; }

        [Display(Name = "Tara Provenienta")]
        public string TaraProvenienta { get; set; }
        public ICollection<Masina> Masini { get; set; }
    }
}
