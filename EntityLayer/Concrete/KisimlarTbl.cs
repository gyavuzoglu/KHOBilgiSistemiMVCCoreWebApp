using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KisimlarTbl
    {
        [Key]
        public long KisimID { get; set; }

        [StringLength(5)]
        public string KisimAdi  { get; set; }
        public int Sinif { get; set; }
        public int BolumID { get; set; }
    }
}
