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
    public class KisimlarTbl
    {
        [Key]
        [StringLength(5)]
        [DisplayName("Kısım Adı")]
        public string? KisimAdi  { get; set; }

        [DisplayName("Sınıf")]
        public int? Sinif { get; set; }

        [ForeignKey("BolumTbl")]

        [DisplayName("Bölüm ID")]
        public int? BolumID { get; set; }

        [ForeignKey("EOYiliTbl")]

        [DisplayName("EOYili ID")]
        public int? EOYiliID { get; set; }
        public List<OgrencilerTbl>? OgrencilerTbl { get; set; }
        public virtual BolumTbl? BolumTbl { get; set; }
        public virtual EOYiliTbl? EOYiliTbl { get; set; }
    }
}
