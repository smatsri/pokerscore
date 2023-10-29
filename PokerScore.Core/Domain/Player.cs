namespace PokerScore.Core.Domain;

public record Player
{
    public int Id { get; set; }
    public required string PlayerName { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public virtual ICollection<Buyin>? Buyins { get; set; }
}
