using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using PokerScore.Data;
using PokerScore.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokerScoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<PokerScore.MyData.MyDataService>();

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<PokerScoreDbContext>()
    .AddFiltering()
    .AddProjections()
    .AddQueryType()
    //.AddMutationType()
    .AddType<PokerScore.MyData.MyDataQueries>()
    .AddType<Query>();

var app = builder.Build();
//app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();
