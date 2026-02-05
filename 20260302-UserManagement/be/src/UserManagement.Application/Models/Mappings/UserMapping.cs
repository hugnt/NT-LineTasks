using System.Linq.Expressions;

using UserManagement.Application.Models.Requests;
using UserManagement.Application.Models.Responses;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Models.Mappings;

public static class UserMapping
{
    public static User ToEntity(this AddUserRequest request) => new()
    {
        Fullname = request.Fullname,
        Email = request.Email,
        Role = request.Role,
        IsActive = request.IsActive
    };

    public static User ToEntity(this UpdateUserRequest request) => new()
    {
        Fullname = request.Fullname,
        Email = request.Email,
        Role = request.Role,
        IsActive = request.IsActive
    };

    public static void MappingFieldFrom(this User trackingEntity, UpdateUserRequest updatedEntity)
    {
        trackingEntity.Fullname = updatedEntity.Fullname;
        trackingEntity.Email = updatedEntity.Email;
        trackingEntity.Role = updatedEntity.Role;
        trackingEntity.IsActive = updatedEntity.IsActive;
    }

    public static Expression<Func<User, UserResponse>> SelectResponseExpression = x => new UserResponse
    {
        Id = x.Id,
        Fullname = x.Fullname,
        Email = x.Email,
        Role = x.Role,
        IsActive = x.IsActive,
    };

    public static Expression<Func<User, UserDetailResponse>> SelectDetailResponseExpression = x => new UserDetailResponse
    {
        Id = x.Id,
        Fullname = x.Fullname,
        Email = x.Email,
        Role = x.Role,
        IsActive = x.IsActive,
        UpdatedAt = x.UpdatedAt,
    };
}
