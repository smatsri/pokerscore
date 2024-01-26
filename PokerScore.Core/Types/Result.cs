namespace PokerScore.Core;

public abstract record Result<T>;
public abstract record Error;

public record Success<T>(T Value) : Result<T>;
public record Failure<T>(Error Error) : Result<T>;

public static class Result
{
    public static Success<T> Success<T>(T value) => new(value);
    public static Failure<T> Failure<T>(Error error) => new(error);
    public static Result<TOut> Bind<T, TOut>(this Result<T> result, Func<T, Result<TOut>> binder)
        => result switch
        {
            Success<T> success => binder(success.Value),
            Failure<T> failure => Failure<TOut>(failure.Error),
            _ => throw new InvalidOperationException("Unexpected result type."),
        };

    public static Result<TOut> Map<T, TOut>(this Result<T> result, Func<T, TOut> mapper)
        => result.Bind(value => Success(mapper(value)));
}