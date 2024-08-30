using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BolumTbl
    {
        [Key]
        public int BolumID { get; set; }

        [StringLength(50)]
        public string? BolumAdi { get; set; }

        public virtual OgrencilerTbl OgrencilerTbl { get; set; }
        public virtual DerslerTbl DerslerTbl { get; set; }
        public virtual KisimlarTbl KisimlarTbl { get; set; }
    }
}
