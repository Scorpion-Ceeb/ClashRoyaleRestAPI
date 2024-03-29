﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.UpdateModel;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayer;

internal class UpdatePlayerCommandValidator : AbstractValidator<UpdateModelCommand<PlayerModel, PlayerId>>
{
    public UpdatePlayerCommandValidator()
    {
        RuleFor(x => x.Model.Alias).NotNull().Length(3, 64);
        RuleFor(x => x.Model.Elo).NotNull().InclusiveBetween(0, 9000);
        RuleFor(x => x.Model.Level).NotNull().InclusiveBetween(1, 15);
    }
}
