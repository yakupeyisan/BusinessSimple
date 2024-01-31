using Core.Repository;

namespace Core.Entities;

public class UserClaim : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid ClaimId { get; set; }
    public virtual Claim Claim { get; set; }
    public virtual User User { get; set; }
}