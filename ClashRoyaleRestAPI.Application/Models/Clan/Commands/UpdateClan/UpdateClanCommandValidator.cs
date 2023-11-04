﻿using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Domain.Models;
using FluentValidation;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdateClan
{
    internal class UpdateClanCommandValidator : AbstractValidator<UpdateModelCommand<ClanModel, int>>
    {
        public UpdateClanCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().NotNull().Length(3, 64);
            RuleFor(x => x.Model.Region).NotEmpty().NotNull().Length(3, 32);
            RuleFor(x => x.Model.TypeOpen).NotEmpty().NotNull();
            RuleFor(x => x.Model.MinTrophies).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
