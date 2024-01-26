using FluentValidation;

namespace PokerScore.Commands;

public record AddBuyin(int PokerSessionId, int PlayerId, int Amount);

public class AddBuyinValidator : AbstractValidator<AddBuyin>
{
    public AddBuyinValidator()
    {
        RuleFor(buyin => buyin.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
    }
}

