using Microsoft.EntityFrameworkCore;
using PokerScore.Data;
using PokerScore.Api;
using PokerScore.Api.Validation;
using HotChocolate.Types.Descriptors;
using System.Reflection;
using HotChocolate.Execution;
using HotChocolate.Execution.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokerScoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<PokerScoreDbContext>()
    .AddFiltering()
    .AddProjections()
    .AddQueryType()
    .AddType<Query>()
    .UseDefaultPipeline()
    .UseRequest<ValidationMiddleware>()
    ;

;

var app = builder.Build();

app.MapGraphQL();

app.Run();