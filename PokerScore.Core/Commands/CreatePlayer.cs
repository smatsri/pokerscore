using FluentValidation;

namespace PokerScore.Commands;

public record CreatePlayer(string PlayerName);

public class CreatePlayerValidator : AbstractValidator<CreatePlayer>
{
    private readonly IPlayerNames _playerNames;

    public CreatePlayerValidator(IPlayerNames playerNames)
    {
        _playerNames = playerNames;

        RuleFor(player => player.PlayerName)
            .NotEmpty().WithMessage("PlayerName is required.")
            .MustAsync(BeUniqueName).WithMessage("PlayerName is already in use.");
    }

    private async Task<bool> BeUniqueName(string playerName, CancellationToken cancellationToken)
        => !await _playerNames.Exists(playerName, cancellationToken);
}

public interface IPlayerNames
{
    Task<bool> Exists(string playerName, CancellationToken cancellationToken);
}