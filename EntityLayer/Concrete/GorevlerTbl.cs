using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GorevlerTbl
    {
        [Key]
        public int GorevID { get; set; }

        [StringLength(150)]
        public string? GorevAdi { get; set; }
    }
}
