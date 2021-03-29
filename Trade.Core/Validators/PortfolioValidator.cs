using FluentValidation;
using System;
using Trade.Core.Interfaces;

namespace Trade.Core.Validators
{
    public class PortfolioValidator : AbstractValidator<IPortfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.N).GreaterThan(0).WithMessage("Number of trades in the portfolio must be always a number bigger then 0.");

            RuleFor(x => x.ReferenceDate).Must(date => date != default(DateTime))
                                        .WithMessage("Reference date invalid.");

            RuleFor(x => x.Trades).NotNull()
                                  .When(x => x.N != x.Trades.Count, ApplyConditionTo.CurrentValidator)
                                  .WithMessage("Number of trades on portfolio must be equal the informed number of trades.");
        }
    }
}

