using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUserTbl:IdentityUser<int>
    {
        [DisplayName("Adı")]
        public string? Adi { get; set; }

        [DisplayName("Soyadı")]
        public string? Soyadi { get; set; }
        
    }
}
