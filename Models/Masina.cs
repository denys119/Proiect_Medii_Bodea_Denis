using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class Masina
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Marca Masina")]

       
        public string Marca { get; set; }

        [Display(Name = "Model Masina")]
        public string Model { get; set; }

        [Display(Name = "Culoare Masina")]
        public string Culoare { get; set; }

        [Display(Name = "An Fabricatie")]
        public int An { get; set; }

        [Display(Name = "Pretul Masinii")]
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]

        public decimal Pret { get; set; }

        [Display(Name = "Data Adaugarii")]
        [DataType(DataType.Date)]
        public DateTime DataAdaugare { get; set; }

        public int AngajatID { get; set; }

        public Angajat Angajat { get; set; }

        public int TaraID { get; set; }

        public Tara Tara { get; set; }

        public ICollection<MasinaCategory> MasinaCategories { get; set; }
    }
}
