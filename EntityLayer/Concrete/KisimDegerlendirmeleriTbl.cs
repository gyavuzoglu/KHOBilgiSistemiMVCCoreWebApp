using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KisimDegerlendirmeleriTbl
    {
        [Key]

        [DisplayName("Kısım Değ.ID")]
        public int KisimDegerlendirmeID { get; set; }

        [StringLength(5)]

        [DisplayName("Kısım Adı")]
        public string? KisimAdi { get; set; }

        [DisplayName("Per.ID")]
        public long PerID { get; set; }

        [DisplayName("Değ.Tarihi")]
        public DateTime TarihSaat { get; set; }

        [DisplayName("Değerlendirme")]
        public string? KisimDegerlendirme { get; set; }

        [DisplayName("Eğt.Öğt.Yılı ID")]
        public int EOYiliID { get; set; }

        [DisplayName("Dönem")]
        public int Donem { get; set; }

    }
}
