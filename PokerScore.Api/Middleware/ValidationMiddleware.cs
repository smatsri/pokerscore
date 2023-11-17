using System.Diagnostics.CodeAnalysis;
using HotChocolate.Execution;
using HotChocolate.Language;

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

        if (context.Operation == null || context.Operation.Type != OperationType.Mutation)
        {
            await next(context).ConfigureAwait(continueOnCapturedContext: false);
        }


        Console.WriteLine("+++++---------validate-----------------++++");
    }

}
