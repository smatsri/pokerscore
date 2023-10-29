namespace PokerScore.Core.Domain;

public record class PokerSession
{
    public int Id { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public virtual ICollection<Buyin>? Buyins { get; set; }
}
