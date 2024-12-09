using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class AkademikDanismanDegerlendirmeListVM
    {
        [StringLength(11)]
        public string OgrenciTC { get; set; }

        [StringLength(150)]
        public string? FotografAdresi { get; set; }

        public int Sinif { get; set; }

        [StringLength(5)]
        public string? KisimAdi { get; set; }

        public int YakaNo { get; set; }

        [StringLength(100)]
        public string? Adi { get; set; }

        [StringLength(100)]
        public string? Soyadi { get; set; }

        [StringLength(100)]

        public string? TurAdi { get; set; }

        public DateTime TarihSaat { get; set; }

        public string? Degerlendirme { get; set; }
    }
}
