using System;

namespace UserManagement.Domain.Primitives;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
