using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AskeriSiniflarTbl
    {
        [Key]
        [DisplayName("Sınf ID")]
        public int SinifID { get; set; }

        [StringLength(20)]
        [DisplayName("Sınıfı")]
        public string? SinifUzun { get; set; }

        [StringLength(10)]
        [DisplayName("Sınıfı")]
        public string? SinifKisa { get; set; }
        public List<PersonelTbl>? PersonelTbl { get; set; }
    }
}
