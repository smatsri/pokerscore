
using Microsoft.EntityFrameworkCore;
using PokerScore.MyData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokerScore.Data.PokerScoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<MyDataService>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()
    .AddType<MyDataQueries>();

var app = builder.Build();


app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
