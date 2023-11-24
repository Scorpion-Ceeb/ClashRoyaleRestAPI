﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer
{
    internal class AddPlayerCommandValidator : AbstractValidator<AddModelCommand<PlayerModel, int>>
    {
        public AddPlayerCommandValidator()
        {
            RuleFor(x => x.Model.Alias).NotNull().Length(3, 64);
            RuleFor(x => x.Model.Elo).NotNull().InclusiveBetween(0, 9000);
            RuleFor(x => x.Model.Level).NotNull().InclusiveBetween(1, 15);
        }
    }
}
