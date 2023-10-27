﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad
{
    internal class GetPlayerByIdFullLoadQueryHandler : IQueryHandler<GetPlayerByIdFullLoadQuery, PlayerModel>
    {
        private readonly IPlayerRepository _repository;

        public GetPlayerByIdFullLoadQueryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PlayerModel>> Handle(GetPlayerByIdFullLoadQuery request, CancellationToken cancellationToken)
        {
            PlayerModel player;
            try
            {
                player = await _repository.GetSingleByIdAsync(request.Id, request.FullLoad);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure<PlayerModel>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return player;
        }
    }
}