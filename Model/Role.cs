using System.ComponentModel.DataAnnotations;

namespace VieWingsAPI.Model
{
    public class Role
    {
        public Role(int roleId, string name) {
            RoleId = roleId;
            Name = name;
        }
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
