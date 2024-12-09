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
    public class DerslerTbl
    {
        [Key]
        [StringLength(8)]
        [DisplayName("Ders Kodu")]
        public string? DersKodu { get; set; }

        [ForeignKey("EOYiliTbl")]
        [DisplayName("Eğt.Öğt.Yılı ID")]
        public int EOYiliID { get; set; }

        [ForeignKey("BolumTbl")]
        [DisplayName("Bölüm ID")]
        public int BolumID { get; set; }

        [StringLength(300)]
        [DisplayName("Ders Adı")]
        public string? DersAdi { get; set; }
        [DisplayName("Haftalık DS")]
        public int HaftalikDS { get; set; }
        public float Kredi {  get; set; }
        public int AKTS { get;  set;}
        [DisplayName("Yaratılma Tarihi")]
        public DateTime YaratilmaTarihi { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime GuncellenmeTarihi { get; set; }

        public virtual EOYiliTbl? EOYiliTbl { get; set; }
        public virtual BolumTbl? BolumTbl { get; set; }
      

    }
}
