using System;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Infrastructure.Persistence.SeedData;

public class UserSeed
{
    public static IEnumerable<User> Users => new List<User>()
    {
        new()
        {
            Id = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            Fullname = "Robert Anderson",
            Email = "robert.anderson@usermanagement.local",
            Role = Role.Admin,
            CreatedAt = new DateTime(2026, 02, 03, 0, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("2f6a0db3-3f8e-4c5c-8a5e-9e0d1b2c3a41"),
            Fullname = "Michael Johnson",
            Email = "michael.johnson@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 1, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 1, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("c6a9e3d1-12f4-4a7a-9d3d-3f1a9c7b2d10"),
            Fullname = "Sarah Williams",
            Email = "sarah.williams@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 2, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 2, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("0b1f5f6e-6c5d-4f12-9b2a-1e3d4c5b6a70"),
            Fullname = "David Brown",
            Email = "david.brown@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 3, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 3, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("9a7c3d2e-5f6b-4c8d-8e1a-2b3c4d5e6f71"),
            Fullname = "Emily Davis",
            Email = "emily.davis@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 4, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 4, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("4e2c1b0d-9f8c-4f4d-9e4b-1b5b0d8bc2a2"),
            Fullname = "James Wilson",
            Email = "james.wilson@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 5, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 5, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("13d0f4a2-7b9c-4d10-8e6f-5a2d7c9e1b33"),
            Fullname = "Jennifer Martinez",
            Email = "jennifer.martinez@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 6, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 6, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("7f3a2c1d-0e9b-4c6d-8f1e-2a3b4c5d6e72"),
            Fullname = "Christopher Taylor",
            Email = "christopher.taylor@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 7, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 7, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("b2c3d4e5-f607-4a18-9b2c-3d4e5f607183"),
            Fullname = "Jessica Thompson",
            Email = "jessica.thompson@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 8, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 8, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("5d6e7f80-1a2b-4c3d-9e0f-1a2b3c4d5e84"),
            Fullname = "Daniel Garcia",
            Email = "daniel.garcia@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 9, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 9, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("f1a2b3c4-d5e6-4f78-9012-3a4b5c6d7e8f"),
            Fullname = "Matthew Anderson",
            Email = "matthew.anderson@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 10, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 10, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("a9b8c7d6-e5f4-4321-9876-5a4b3c2d1e0f"),
            Fullname = "Ashley White",
            Email = "ashley.white@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 11, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 11, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("3e4f5a6b-7c8d-4e9f-0a1b-2c3d4e5f6a7b"),
            Fullname = "Joshua Harris",
            Email = "joshua.harris@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 12, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 12, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("8c9d0e1f-2a3b-4c5d-6e7f-8a9b0c1d2e3f"),
            Fullname = "Amanda Clark",
            Email = "amanda.clark@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 13, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 13, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("1f2e3d4c-5b6a-4798-8a9b-0c1d2e3f4a5b"),
            Fullname = "Andrew Lewis",
            Email = "andrew.lewis@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 14, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 14, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("6b7c8d9e-0f1a-4b2c-3d4e-5f6a7b8c9d0e"),
            Fullname = "Melissa Robinson",
            Email = "melissa.robinson@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 15, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 15, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("d0e1f2a3-b4c5-4d6e-7f8a-9b0c1d2e3f4a"),
            Fullname = "Kevin Walker",
            Email = "kevin.walker@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 16, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 16, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("5a6b7c8d-9e0f-4a1b-2c3d-4e5f6a7b8c9d"),
            Fullname = "Stephanie Hall",
            Email = "stephanie.hall@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 17, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 17, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("9c0d1e2f-3a4b-4c5d-6e7f-8a9b0c1d2e3f"),
            Fullname = "Brian Young",
            Email = "brian.young@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 18, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 18, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = true,
        },
        new()
        {
            Id = Guid.Parse("2d3e4f5a-6b7c-4d8e-9f0a-1b2c3d4e5f6a"),
            Fullname = "Nicole King",
            Email = "nicole.king@usermanagement.local",
            Role = Role.User,
            CreatedAt = new DateTime(2026, 02, 03, 19, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2026, 02, 03, 19, 0, 0, DateTimeKind.Utc),
            CreatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            UpdatedBy = Guid.Parse("8b0d5b1b-4b9e-4d4f-8c9f-7d7f9b84e2c1"),
            IsActive = false,
        },
    };
}
