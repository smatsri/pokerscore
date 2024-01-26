namespace PokerScore.Api;
using PokerScore.Core.Domain;
using PokerScore.Data;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class Query
{

    [UseProjection]
    [UseFiltering]
    public IQueryable<Buyin> GetBuyins(PokerScoreDbContext db)
        => db.Buyins;

    [UseProjection]
    [UseFiltering]
    public IQueryable<PokerSession> GetPokerSessions(PokerScoreDbContext db)
        => db.PokerSessions;

}