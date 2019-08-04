using FluentValidation;
using Token.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Token.Service.Validators
{
    public class TokenValidator : AbstractValidator<TokenEntity>
    {
        public TokenValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.CardNumber)
                .NotEmpty().WithMessage("Is necessary to inform the CVV.")
                .NotNull().WithMessage("Is necessary to inform the CVV.");

            RuleFor(c => c.CVV)
                .NotEmpty().WithMessage("Is necessary to inform the CVV.")
                .NotNull().WithMessage("Is necessary to inform the CVV.");

            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("Is necessary to inform the Date.")
                .NotNull().WithMessage("Is necessary to inform the Date.");
        }
    }
}
