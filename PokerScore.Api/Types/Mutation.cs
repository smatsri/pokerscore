using System.ComponentModel.DataAnnotations;
using FluentValidation;
using PokerScore.Core.Domain;
using PokerScore.Data;

namespace PokerScore.Api;
public record StartPokerSessionInput(string Title);
public record StartPokerSessionPayload(bool Success);
public record AddBuyinInput(int Amout, int PokerSessionId);

public class StartPokerSessionInputValidator : AbstractValidator<StartPokerSessionInput>
{
    public StartPokerSessionInputValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);
    }


}

[ExtendObjectType(OperationTypeNames.Mutation)]
internal sealed class Mutation
{
    [UseMutationConvention]
    public async Task<StartPokerSessionPayload> StartPokerSession(
       StartPokerSessionInput input,
       PokerScoreDbContext dbContext)
    {
        var session = new PokerSession
        {
            CreatedAt = DateTimeOffset.Now
        };

        // dbContext.PokerSessions.Add(session);

        // await dbContext.SaveChangesAsync();

        return new StartPokerSessionPayload(true);
    }

}