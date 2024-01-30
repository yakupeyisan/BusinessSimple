using System;
namespace Core.Repository;

public abstract class Entity
{
}

public abstract class Entity<T>
{
    public T Id { get; set; }
}

