﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetAllOpen;

public record GetAllOpenChallengeQuery() : IQuery<IEnumerable<ChallengeModel>>;
