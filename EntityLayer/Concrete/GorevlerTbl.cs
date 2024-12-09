using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GorevlerTbl
    {
        [Key]
        [DisplayName("Görev ID")]
        public int GorevID { get; set; }

        [StringLength(150)]
        [DisplayName("Görev Adı")]
        public string? GorevAdi { get; set; }
        public List<PersonelTbl>? PersonelTbl { get; set; }
    }
}
