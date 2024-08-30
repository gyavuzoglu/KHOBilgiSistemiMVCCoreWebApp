using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRolesTbl
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserTbl")]
        [StringLength(11)]
        public string? UserTC { get; set; }

        [ForeignKey("RolesTbl")]
        public int RoleID { get; set; }

        public virtual UserTbl? UserTbl { get; set; }
        public virtual RolesTbl? RolesTbl { get; set; }
    }
}