using System.ComponentModel.DataAnnotations.Schema;

namespace tickets.shared.DTOs
{
    [NotMapped]
    public class RolesDTO
    {
        public string RoleID { get; set; }
        public string Name { get; set; }
    }
}
