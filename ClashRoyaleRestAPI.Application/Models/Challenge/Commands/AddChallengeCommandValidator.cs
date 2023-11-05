﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands
{
    internal class AddChallengeCommandValidator : AbstractValidator<AddModelCommand<ChallengeModel, int>>
    {
        public AddChallengeCommandValidator()
        {
            RuleFor(x => x.Model.AmountReward).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.DurationInHours).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty().Length(3, 32);
            RuleFor(x => x.Model.Cost).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Model.Description).NotNull().NotEmpty();
            RuleFor(x => x.Model.StartDate).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x=> x.Model.LossLimit).NotNull().NotEmpty().GreaterThanOrEqualTo(3);
            RuleFor(x=> x.Model.MinLevel).NotNull().NotEmpty().InclusiveBetween(1, 15);
        }
    }
}
