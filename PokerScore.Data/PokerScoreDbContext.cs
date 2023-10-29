using Microsoft.EntityFrameworkCore;
using PokerScore.Core.Domain;

namespace PokerScore.Data;

public class PokerScoreDbContext : DbContext
{
    public PokerScoreDbContext(DbContextOptions<PokerScoreDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Buyin> Buyins { get; set; }
    public DbSet<PokerSession> PokerSessions { get; set; }

}
