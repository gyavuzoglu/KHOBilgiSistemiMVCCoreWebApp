using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AskeriSiniflarTbl
    {
        [Key]
        public int SinifID { get; set; }

        [StringLength(20)]
        public string? SinifUzun { get; set; }

        [StringLength(10)]
        public string? SinifKisa { get; set; }
        public virtual PersonelTbl PersonelTbl { get; set; }
    }
}
