﻿namespace PokerScore.Core.Domain;

public record class Buyin
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int PokerSessionId { get; set; }
    public int Amount { get; set; }
    public DateTimeOffset Date { get; set; }
    public virtual Player? Player { get; set; }
    public virtual PokerSession? PokerSession { get; set; }

}
