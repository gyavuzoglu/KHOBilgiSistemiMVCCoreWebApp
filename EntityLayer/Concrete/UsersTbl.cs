using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UsersTbl
    {
        [Key]
        public long UserTC { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }
        public int ProfilID { get; set; }
        public DateTime SifreGuncellemeTarihi { get; set; }
        public DateTime YaratilmaTarihi { get; set; }
        public bool Pasif { get; set; } //Pasifse 1 olacak


    }
}
