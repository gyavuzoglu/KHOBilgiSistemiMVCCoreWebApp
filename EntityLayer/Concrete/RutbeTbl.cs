using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RutbeTbl
    {
        [Key]
        public int RutbeID { get; set; }

        [StringLength(20)]
        public string? RutbeUzun { get; set; }

        [StringLength(10)]
        public string? RutbeKisa { get; set; }
        public List<PersonelTbl>? PersonelTbl { get; set; }
    }
}
