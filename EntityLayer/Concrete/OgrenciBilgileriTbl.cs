using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OgrenciBilgileriTbl
    {
        [Key]

        public long OgrenciID { get; set; }

        [StringLength(11)]
        [DisplayName("Öğrenci TC No")]
        public string? OgrenciTC { get; set; }

        [DisplayName("Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }

        [DisplayName("Okula Giriş Tarihi")]
        public DateTime OkulaGirisTarihi { get; set; }

        [StringLength(50)]

        [DisplayName("Anne Adı")]
        public string? AnneAdi { get; set; }

        [StringLength(50)]

        [DisplayName("Baba Adı")]
        public string? BabaAdi { get; set; }

        [StringLength(50)]

        [DisplayName("Doğum Yeri")]
        public string? DogumYeri { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }

        [StringLength(20)]

        [DisplayName("Anne-Baba Medeni Durumu")]
        public string? AnneBabaMedeniDurum { get; set; }
        
        [StringLength(50)]

        [DisplayName("Anne Eğitim")]
        public string? AnneEgitim { get; set; }

        [StringLength(50)]

        [DisplayName("Baba Eğitim")]
        public string? BabaEgitim { get; set; }

        [DisplayName("Anne Gelir")]
        public int AnneGelir { get; set; }

        [DisplayName("Baba Gelir")]
        public int BabaGelir { get; set; }

        [DisplayName("Öğc.Gelir")]
        public int OgrenciGelir { get; set; }

        [DisplayName("Kardeş Sayısı")]
        public int KardesSayisi { get; set; }

        [DisplayName("Lise Dip.Notu")]
        public float LiseDiplomaNotu { get; set; } //decimal(5,2)

        [DisplayName("MSÜ Puanı")]
        public float MSUPuani { get; set; } //decimal(6,3)

        [DisplayName("ÖSYM Puanı")]
        public float OSYMPuani { get; set; } //decimal(6,3)

        [DisplayName("Disiplin Puanı")]
        public float DisiplinPuani { get; set; } //decimal(4,1)

        public virtual OgrencilerTbl? OgrencilerTbl { get; set; }

    }
}
