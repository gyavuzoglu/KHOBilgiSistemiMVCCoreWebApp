using System;
using System.Collections.Generic;
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
        public string? DersKodu { get; set; }

        [ForeignKey("EOYiliTbl")]
        public int EOYiliID { get; set; }

        [ForeignKey("BolumTbl")]
        public int BolumID { get; set; }

        [StringLength(300)]
        public string? DersAdi { get; set; }
        public int HaftalikDS { get; set; }
        public float Kredi {  get; set; }
        public int AKTS { get;  set;}
        public DateTime YaratilmaTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public virtual EOYiliTbl? EOYiliTbl { get; set; }
        public virtual BolumTbl? BolumTbl { get; set; }
      

    }
}
