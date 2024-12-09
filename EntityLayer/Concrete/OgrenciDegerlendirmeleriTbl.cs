using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OgrenciDegerlendirmeleriTbl
    {
        [Key]

        [DisplayName("Değ.ID")]
        public int DegerlendirmeID { get; set; }

        [ForeignKey("OgrenciDegerlendirmeTurleriTbl")]

        [DisplayName("Değ.Tür ID")]
        public int DegTurID { get; set; }

        [ForeignKey("OgrencilerTbl")]

        [DisplayName("Öğc.ID")]
        public int OgrenciID { get; set; }

        [ForeignKey("PersonelTbl")]

        [DisplayName("Per.ID")]
        public int PerID { get; set; }

        [DisplayName("Değ.Tarihi")]
        public DateTime TarihSaat { get; set; }

        [DisplayName("Değerlendirme")]
        public string? Degerlendirme { get; set; }

        [ForeignKey("EOYiliTbl")]

        [DisplayName("Eğt.Öğt.Yılı")]
        public int EOYiliID { get; set; }

        [DisplayName("Dönem")]
        public int Donem { get; set; }

        public virtual OgrenciDegerlendirmeTurleriTbl? OgrenciDegerlendirmeTurleriTbl { get; set; }
        public virtual OgrencilerTbl? OgrencilerTbl { get; set; }
        public virtual PersonelTbl? PersonelTbl { get; set; }
        public virtual EOYiliTbl? EOYiliTbl { get; set; }

    }
}
