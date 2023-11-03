using HotChocolate.Execution;

namespace PokerScore.Api.Validation;

internal sealed class ValidationMiddleware
{
    private readonly HotChocolate.Execution.RequestDelegate next;

    public ValidationMiddleware(HotChocolate.Execution.RequestDelegate next)
    {
        this.next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async ValueTask InvokeAsync(IRequestContext context)
    {
        Console.WriteLine("+++++---------validate------------------------++++");
        await next(context).ConfigureAwait(continueOnCapturedContext: false);
    }

}
