using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProfilTbl
    {
        [Key]
        public int ProfilID { get; set; }

        [StringLength(20)]
        public string ProfilAdi { get; set; }
    }
}
