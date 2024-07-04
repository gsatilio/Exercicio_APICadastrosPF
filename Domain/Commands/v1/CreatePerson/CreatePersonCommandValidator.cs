using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    private const int MinimumAge = 18;
    private const int MinimumNameLength = 5;
    private const int MinimumDocLength = 11;
    private readonly Regex _onlyNumbers = new(@"[^\d]", RegexOptions.Compiled, TimeSpan.FromMilliseconds(1));

    public CreatePersonCommandValidator()
    {
        RuleFor(createPersonCommand => createPersonCommand.Birthday)
            .Must(createPersonCommand => DateTime.Now.Year - createPersonCommand.Year >= MinimumAge)
            .WithMessage("Idade deve ser maior que 18 anos!"); // TODO colocar essas mensagens em constantes para poder fazer validação no teste

        RuleFor(createPersonCommand => createPersonCommand.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .MinimumLength(MinimumNameLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumNameLength} caracteres!");

        RuleFor(createPersonCommand => createPersonCommand.Document)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .Must(x => _onlyNumbers.Replace(x, string.Empty).Length == MinimumDocLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumDocLength} caracteres!");
    }
}