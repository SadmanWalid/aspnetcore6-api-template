using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.DTO.Security
{
    public class UserDTO
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="Exceeded Character limit of 50")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Exceeded Character limit of 50")]
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int RoleId { get; set; }

        // for jwt
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ExpirationTime { get; set; }
    }
}
