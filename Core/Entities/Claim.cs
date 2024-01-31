using Core.Repository;

namespace Core.Entities;

public class Claim : Entity<Guid>
{
    public string Group { get; set; }
    public string Name { get; set; }
    public UserClaim UserClaim { get; set; }
}
