using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PersonelTbl
    {
        [Key]
        public long PersonelTC { get; set; }

        [StringLength(50)]
        public string? Adi { get; set; }

        [StringLength(50)]
        public string? Soyadi { get; set; }

        public int SinifID { get; set; }
        public int RutbeID { get; set; }
        public int UnvanID { get; set; }
        public int GorevID { get; set; }
        public int BolumID { get; set; }
        public int BirimID { get; set; }
        public bool MisafirPersonel { get; set; }

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
        public int DahiliTelefonu { get; set; }
        public DateTime KayitTarihi { get; set; }





    }
}
