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
        [DisplayName("Per.ID")]
        public long PerId { get; set; }
       
        [StringLength(11)]
        [DisplayName("Per.TC No")]
        public string PersonelTC { get; set; }

        [StringLength(50)]
        [DisplayName("Per.Adı")]
        public string Adi { get; set; }

        [StringLength(50)]
        [DisplayName("Per.Soyadı")]
        public string Soyadi { get; set; }

        [ForeignKey("AskeriSiniflarTbl")]
        [DisplayName("Sınıf ID")]
        public int? SinifID { get; set; } = 1;

        [ForeignKey("RutbeTbl")]
        [DisplayName("Rütbe ID")]
        public int? RutbeID { get; set; } = 1;

        [ForeignKey("UnvanTbl")]
        [DisplayName("Unvan ID")]
        public int? UnvanID { get; set; } = 1;

        [ForeignKey("GorevlerTbl")]
        [DisplayName("Görev ID")]
        public int? GorevID { get; set; } = 1;

        [ForeignKey("BolumTbl")]
        [DisplayName("Görev ID")]
        public int? BolumID { get; set; } = 1;

        [ForeignKey("BirimlerTbl")]
        [DisplayName("Birim ID")]
        public int? BirimID { get; set; } = 1;

        [DisplayName("Misafir Personel")]
        public bool MisafirPersonel { get; set; } =false;

        [StringLength(150)]
        [DisplayName("Mis.Görev Yeri")]
        public string? MisafirGorevYeri { get; set; }

        [StringLength(200)]
        [DisplayName("Mis.Ev Adresi")]
        public string? MisafirEvAdresi { get; set; }

        [StringLength(100)]
        [DisplayName("Okul E-Posta")]
        public string? OkulEPosta { get; set; }

        [StringLength(100)]
        [DisplayName("Diğer E-Posta")]
        public string? DigerEPosta { get; set; }

        [StringLength(10)]
        [DisplayName("Cep Telefonu")]
        public string? CepTelefonu { get; set; }
        [DisplayName("Dahili Tel.")]
        public int? DahiliTelefonu { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime? KayitTarihi { get; set; }=DateTime.Now;

        public virtual BolumTbl? BolumTbl { get; set; }
        public virtual GorevlerTbl? GorevlerTbl { get; set; }
        public virtual BirimlerTbl? BirimlerTbl { get; set; }
        public virtual RutbeTbl? RutbeTbl { get; set; }
        public virtual UnvanTbl? UnvanTbl { get; set; }
        public virtual AskeriSiniflarTbl? AskeriSiniflarTbl { get; set; }
        public virtual OgrenciDegerlendirmeleriTbl? OgrenciDegerlendirmeleriTbl { get; set; }



    }
}
