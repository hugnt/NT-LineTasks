using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Enums;

namespace UserManagement.Application.Models.Requests;

public class UserRequest
{
    [Required]
    public required string Fullname { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }
    public Role Role { get; set; }
    public bool IsActive { get; set; }
}

public class AddUserRequest : UserRequest
{
}

public class UpdateUserRequest : UserRequest
{
}

public class UpdateActiveStatusRequest
{
    public bool IsActive { get; set; }
}