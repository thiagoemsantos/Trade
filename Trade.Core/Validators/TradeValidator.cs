using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Trade.Core.Interfaces;

namespace Trade.Core.Validators
{
    public class TradeValidator : AbstractValidator<ITrade>
    {
        private static readonly List<string> CLIENT_SECTORS = new List<string>() { "PUBLIC", "PRIVATE" };

        public TradeValidator()
        {
            RuleFor(x => x.ClientSector).Cascade(CascadeMode.Stop)
                                     .NotEmpty().WithMessage("Client Sector is required.")
                                     .Must(c => CLIENT_SECTORS.Any(o => o.ToUpper() == c.ToUpper()))
                                     .WithMessage("Client Sector must be Public or Private.");

            RuleFor(x => x.NextPaymentDate)
                                        .Must(date => date != default(DateTime))
                                        .WithMessage("Next Payment Date is required.");

            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Value is invalid.");
        }

    }
}
