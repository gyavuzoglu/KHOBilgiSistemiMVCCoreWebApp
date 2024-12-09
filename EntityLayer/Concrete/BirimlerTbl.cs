using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BirimlerTbl
    {
        [Key]
        [DisplayName("Birim ID")]
        public int BirimID { get; set; }

        [StringLength(150)]
        [DisplayName("Birim Adı")]
        public string? BirimAdi { get; set; }
        public List<PersonelTbl>? PersonelTbl { get; set; }
    }
}
