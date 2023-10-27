﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer
{
    public class GetAllCardOfPlayerQueryHandler : IQueryHandler<GetAllCardOfPlayerQuery, IEnumerable<CardModel>>
    {
        private readonly IPlayerRepository _repository;

        public GetAllCardOfPlayerQueryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<CardModel>>> Handle(GetAllCardOfPlayerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CardModel> cards;

            try
            {
                cards = await _repository.GetAllCardsOfPlayerAsync(request.Id);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure<IEnumerable<CardModel>>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return Result.Create(cards);
        }
    }
}