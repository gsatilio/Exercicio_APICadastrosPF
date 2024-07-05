using Domain.Queries.v1;
using FluentValidation;
using System.Reflection;
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
            .WithMessage("Idade deve ser maior que 18 anos!");

        RuleFor(createPersonCommand => createPersonCommand.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .MinimumLength(MinimumNameLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumNameLength} caracteres!");

        RuleFor(createPersonCommand => createPersonCommand.Document)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
            .Must(x => _onlyNumbers.Replace(x, string.Empty).Length == MinimumDocLength)
            .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumDocLength} caracteres!")
            .Must(ValidateDocument)
            .WithMessage("O documento CPF informado é inválido!");
    }



    public static bool ValidateDocument(string document)
    {
        int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string auxDocument;
        string digit;
        int calc;
        int remainder;
        document = document.Trim();
        document = document.Replace(".", "").Replace("-", "");

        if (document.Length != 11)
            return false;

        auxDocument = document.Substring(0, 9);
        calc = 0;

        for (int i = 0; i < 9; i++)
            calc += int.Parse(auxDocument[i].ToString()) * multiplier1[i];

        remainder = calc % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = remainder.ToString();
        auxDocument = auxDocument + digit;
        calc = 0;

        for (int i = 0; i < 10; i++)
            calc += int.Parse(auxDocument[i].ToString()) * multiplier2[i];

        remainder = calc % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = digit + remainder.ToString();

        return document.EndsWith(digit);
    }
}