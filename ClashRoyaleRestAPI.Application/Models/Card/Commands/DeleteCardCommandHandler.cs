﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.Commands
{
    internal class DeleteCardCommandHandler : DeleteModelCommandHandler<CardModel, int>
    {
        public DeleteCardCommandHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
