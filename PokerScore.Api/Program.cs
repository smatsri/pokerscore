using Microsoft.EntityFrameworkCore;
using PokerScore.Data;
using PokerScore.Api;
using PokerScore.Api.Validation;
using FluentValidation.DependencyInjectionExtensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PokerScoreDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<PokerScoreDbContext>()
    .AddFiltering()
    .AddProjections()
    .AddQueryType()
    .AddMutationType()
    .AddType<Query>()
    .AddType<Mutation>()
    .UseDefaultPipeline()
    .UseRequest<ValidationMiddleware>()
    ;

;

var app = builder.Build();

app.MapGraphQL();

app.Run();