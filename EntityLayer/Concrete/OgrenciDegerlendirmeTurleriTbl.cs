using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OgrenciDegerlendirmeTurleriTbl
    {
        [Key]

        [DisplayName("Değ.Tür ID")]
        public int DegTurID { get; set; }

        [StringLength(100)]

        [DisplayName("Tür Adı")]
        public string? TurAdi { get; set; }

        public List<OgrenciDegerlendirmeleriTbl>? OgrenciDegerlendirmeleriTbl { get; set; }
    }
}
