using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Model.Security
{
    [Table("Users", Schema = "Sec")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
