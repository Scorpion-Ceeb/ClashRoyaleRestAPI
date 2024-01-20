﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard
{
    public record AddCardCommand(Guid PlayerId, int CardId) : ICommand;
}
