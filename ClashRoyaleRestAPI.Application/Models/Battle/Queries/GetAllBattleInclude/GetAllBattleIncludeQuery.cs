﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetAllBattleInclude;

public record GetAllBattleIncludeQuery(string? SortOrder,
                                       int Page = 1,
                                       int PageSize = 10) : IQuery<PageList<BattleModel>>;
