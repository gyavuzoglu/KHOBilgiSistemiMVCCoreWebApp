using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UnvanTbl
    {
        [Key]
        public int UnvanID { get; set; }

        [StringLength(30)]
        public string? UnvanUzun { get; set; }

        [StringLength(20)]
        public string? UnvanKisa { get; set;}
        public List<PersonelTbl>? PersonelTbl { get; set; }
    }
}
