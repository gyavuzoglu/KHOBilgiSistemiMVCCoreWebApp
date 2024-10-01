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
    public class PersonelTbl
    {
        [Key]
        [StringLength(11)]
        public string PersonelTC { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [ForeignKey("AskeriSiniflarTbl")]
        public int? SinifID { get; set; } = 1;

        [ForeignKey("RutbeTbl")]
        public int? RutbeID { get; set; } = 1;

        [ForeignKey("UnvanTbl")]
        public int? UnvanID { get; set; } = 1;

        [ForeignKey("GorevlerTbl")]
        public int? GorevID { get; set; } = 1;

        [ForeignKey("BolumTbl")]
        public int? BolumID { get; set; } = 1;

        [ForeignKey("BirimlerTbl")]
        public int? BirimID { get; set; } = 1;

        [DisplayName("Misafir Personel")]
        public bool MisafirPersonel { get; set; } =false;

        [StringLength(150)]
        public string? MisafirGorevYeri { get; set; }

        [StringLength(200)]
        public string? MisafirEvAdresi { get; set; }

        [StringLength(100)]
        public string? OkulEPosta { get; set; }

        [StringLength(100)]
        public string? DigerEPosta { get; set; }

        [StringLength(10)]
        public string? CepTelefonu { get; set; }
        public int? DahiliTelefonu { get; set; }
        public DateTime? KayitTarihi { get; set; }=DateTime.Now;

        public virtual BolumTbl? BolumTbl { get; set; }
        public virtual GorevlerTbl? GorevlerTbl { get; set; }
        public virtual BirimlerTbl? BirimlerTbl { get; set; }
        public virtual RutbeTbl? RutbeTbl { get; set; }
        public virtual UnvanTbl? UnvanTbl { get; set; }
        public virtual AskeriSiniflarTbl? AskeriSiniflarTbl { get; set; }



    }
}
