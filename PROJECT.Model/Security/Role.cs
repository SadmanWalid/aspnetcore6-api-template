using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Model.Security
{
    [Table("Roles", Schema = "Sec")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}