using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BirimlerTbl
    {
        [Key]
        public int BirimID { get; set; }

        [StringLength(150)]
        public string BirimAdi { get; set; }
    }
}
