using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AkademikDanismanlarTbl
    {
        [Key]
        [DisplayName("Danışman ID")]
        public int DanismanlikID { get; set; }

        [DisplayName("Per.ID")]
        public int PerID { get; set; }

        [DisplayName("Görev ID")]
        public int GorevID { get;set; }

        [DisplayName("Sınıf ID")]
        public int Sinif { get; set; }

        [DisplayName("Eğt.Öğt.Yılı ID")]
        public int EOYiliID { get; set; }

        [StringLength(5)]

        [DisplayName("Kısım Adı")]
        public string? KisimAdi { get; set; }


    }
}
