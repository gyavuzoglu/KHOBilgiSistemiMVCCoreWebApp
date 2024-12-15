using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DonemlerTbl
    {
        [Key]
        public int Donem { get; set; }

        [StringLength(10)]
        public string DonemAdi { get; set; }
    }
}
