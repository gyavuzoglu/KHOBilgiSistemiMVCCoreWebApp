using System;
using System.Collections.Generic;
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
        [ForeignKey("OgrencilerTbl")]
        public long OgrenciTC { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime OkulaGirisTarihi { get; set; }

        [StringLength(50)]
        public string? AnneAdi { get; set; }

        [StringLength(50)]
        public string? BabaAdi { get; set; }

        [StringLength(50)]
        public string? DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }

        [StringLength(20)]
        public string? AnneBabaMedeniDurum { get; set; }
        
        [StringLength(50)]
        public string? AnneEgitim { get; set; }

        [StringLength(50)]
        public string? BabaEgitim { get; set; }

        public int AnneGelir { get; set; }
        public int BabaGelir { get; set; }

        public int OgrenciGelir { get; set; }

        public int KardesSayisi { get; set; }

        public float LiseDiplomaNotu { get; set; } //decimal(5,2)

        public float MSUPuani { get; set; } //decimal(6,3)

        public float OSYMPuani { get; set; } //decimal(6,3)

        public float DisiplinPuani { get; set; } //decimal(4,1)

        public virtual OgrencilerTbl? OgrencilerTbl { get; set; }

    }
}
