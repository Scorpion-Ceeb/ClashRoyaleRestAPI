﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries.GetUpCommingWars;

internal class GetUpComingWarsQueryHandler : IQueryHandler<GetUpComingWarsQuery, IEnumerable<WarModel>>
{
    private readonly IWarRepository _repository;

    public GetUpComingWarsQueryHandler(IWarRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<WarModel>>> Handle(GetUpComingWarsQuery request, CancellationToken cancellationToken)
    {
        //var upcomingsWars = await _repository.GetModelDataAsync(new GetWarByDateSpecification(request.Date));
        var upcomingsWars = await _repository.GetWarsByDate(request.Date);

        return Result.Create(upcomingsWars);
    }
}
