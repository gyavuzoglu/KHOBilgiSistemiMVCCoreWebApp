using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KullaniciHareketleriTbl
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserTbl")]
        public long UserTC { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public List<UserTbl> UserTbl { get; set; }

    }
}
