using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EOYiliTbl
    {
        [Key]
        [DisplayName("Eğt.Öğt.Yılı ID")]
        public int EOYiliID { get; set; }

        [StringLength(10)]
        [DisplayName("Eğt.Öğt.Yılı")]
        public string? EOYili { get;set; }
        public List<DerslerTbl>? DerslerTbl { get; set; }
        public List<KisimlarTbl>? KisimlarTbl { get; set; }
    }
}
