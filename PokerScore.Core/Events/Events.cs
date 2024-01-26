namespace PokerScore.Events;

public record SessionCreated(DateTimeOffset Date);
public record BuyIdAdded(int PlayerId, int PokerSessionId, int Amount, DateTimeOffset Date);