﻿using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Challenge;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class ChallengeRepository : BaseRepository<ChallengeModel, ChallengeId>, IChallengeRepository
{
    public ChallengeRepository(ClashRoyaleDbContext context) : base(context)
    {
    }


    #region Interface Methods

    public async Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges()
    {
        return await ApplySpecification(new GetAllChallengeOpenSpecification()).ToListAsync();
    }

    #endregion

}
