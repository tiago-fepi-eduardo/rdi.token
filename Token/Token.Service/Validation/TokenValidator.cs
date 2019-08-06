using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using Token.Domain.Entity;

namespace Token.Service.Validation
{
    public class TokenValidator : AbstractValidator<TokenEntity>
    {
        public TokenValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("TokenEntity not found the object.");
                    });

            RuleFor(c => c.CardNumber)
                .NotEmpty().WithMessage("CardNumber necessary to inform the CVV.")
                .NotNull().WithMessage("CardNumber necessary to inform the CVV.");

            RuleFor(c => c.CVV)
                .NotEmpty().WithMessage("CVV necessary to inform the CVV.")
                .NotNull().WithMessage("CVV necessary to inform the CVV.")
                .ExclusiveBetween(0, 999).WithMessage("CVV has to be > 0.");

            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("Date necessary to inform the Date.")
                .NotNull().WithMessage("Date necessary to inform the Date.");
        }

        public ValidationResult ValidateDecode(string token, DateTime date)
        {
            ValidationResult validationResult;

            if (string.IsNullOrEmpty(token))
                return new ValidationResult("Token is empty or null");
            else if (date == DateTime.MinValue)
                return new ValidationResult("Date is empty or null");
            else
                return new ValidationResult("");
        }
    }
}
