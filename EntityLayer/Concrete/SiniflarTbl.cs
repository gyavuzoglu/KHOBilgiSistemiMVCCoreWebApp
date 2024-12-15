using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SiniflarTbl
    {
        [Key]
        public int Sinif { get; set; }

        [StringLength(20)]
        public string SinifAdi { get; set; }
    }
}
