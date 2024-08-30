using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserTbl
    {
        [Key]
        public long UserTC { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }
        public DateTime SifreGuncellemeTarihi { get; set; }
        public DateTime YaratilmaTarihi { get; set; }
        public bool Pasif { get; set; } //Pasifse 1 olacak

        public virtual KullaniciHareketleriTbl KullaniciHareketleriTbl { get; set; }
        public virtual UserRolesTbl UserRolesTbl { get; set; }
        public virtual OgrencilerTbl OgrencilerTbl { get; set; }
        public virtual PersonelTbl PersonelTbl { get; set; }
         

    }
}
