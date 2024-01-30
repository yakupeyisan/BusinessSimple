using System;
using Core.Repository;

namespace Entities.Models;

public class User:Entity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public short BirthYear { get; set; }
}

