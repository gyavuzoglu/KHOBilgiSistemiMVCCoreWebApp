using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EOYiliTbl
    {
        [Key]
        public int EOYiliID { get; set; }

        [StringLength(10)]
        public string? EOYili { get;set; }
        public List<DerslerTbl>? DerslerTbl { get; set; }
    }
}
