using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Medii_Bodea_Denis.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<MasinaCategory> MasinaCategories { get; set; }
    }
}
