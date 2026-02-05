using UserManagement.Domain.Enums;

namespace UserManagement.Application.Models.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public bool IsActive { get ; set ; }

}


public class UserDetailResponse : UserResponse
{
    public DateTime UpdatedAt { get; set; }
}