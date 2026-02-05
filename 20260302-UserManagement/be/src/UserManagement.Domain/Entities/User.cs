using UserManagement.Domain.Enums;
using UserManagement.Domain.Primitives;

namespace UserManagement.Domain.Entities;

public class User : Entity
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get ; set ; }
    public DateTime UpdatedAt { get ; set ; }
    public Guid CreatedBy { get ; set ; }
    public Guid UpdatedBy { get ; set ; }
    public bool IsActive { get ; set ; }
}
