using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Personelmi { get; set; }
        public bool Ogrencimi { get; set; }
        public bool AktifPasif { get; set; } //Pasifse 1 olacak

        public List<KullaniciHareketleriTbl>? KullaniciHareketleriTbl { get; set; }
        public List<UserRolesTbl>? UserRolesTbl { get; set; } //
        
         

    }
}
