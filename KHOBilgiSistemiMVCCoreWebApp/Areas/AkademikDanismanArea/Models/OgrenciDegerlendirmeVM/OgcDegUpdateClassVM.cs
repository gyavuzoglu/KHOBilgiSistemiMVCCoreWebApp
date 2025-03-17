using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class OgcDegUpdateClassVM
    {
        public int DegTurID { get; set; }

        public long OgrenciID { get; set; }

        public long PerID { get; set; }

        public DateTime TarihSaat { get; set; }

        public string? Degerlendirme { get; set; }

        public int EOYiliID { get; set; }

        public int Donem { get; set; }
    }
}
