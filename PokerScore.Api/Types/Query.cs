using PokerScore.Core.Domain;
using PokerScore.Data;

namespace PokerScore.Api;

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