using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RolesTbl
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string? RoleName { get; set; }

        public List<UserRolesTbl>? UserRolesTbl { get; set; }
    }
}
