﻿using ClashRoyaleRestAPI.Domain.DomainEvents;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Models;

public class ChallengeModel : Entity<ChallengeId>
{
    private ChallengeModel(Guid id)
    {
        Id = ValueObjectId.Create<ChallengeId>(id);
    }
    private ChallengeModel()
    {
    }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public int Cost { get; private set; }
    public int AmountReward { get; private set; }
    public DateTime StartDate { get; private set; }
    public int DurationInHours { get; private set; }
    public bool IsOpen { get; private set; }
    public int MinLevel { get; private set; }
    public int LossLimit { get; private set; }

    public static ChallengeModel Create(string name,
                                        string description,
                                        int cost,
                                        int amountReward,
                                        DateTime start,
                                        int durationInHours,
                                        bool isOpen,
                                        int minLevel,
                                        int lossLimit)
    {
        var challenge = new ChallengeModel(Guid.NewGuid())
        {
            Name = name,
            Description = description,
            Cost = cost,
            AmountReward = amountReward,
            StartDate = start,
            DurationInHours = durationInHours,
            IsOpen = isOpen,
            MinLevel = minLevel,
            LossLimit = lossLimit
        };

        challenge.RaiseDomainEvent(new ChallengeCreatedDomainEvent(Guid.NewGuid(), challenge.Id.Value));

        return challenge;
    }

    public static ChallengeModel Create(Guid id,
                                        string name,
                                        string description,
                                        int cost,
                                        int amountReward,
                                        DateTime start,
                                        int durationInHours,
                                        bool isOpen,
                                        int minLevel,
                                        int lossLimit)
    {
        return new ChallengeModel()
        {
            Id = ValueObjectId.Create<ChallengeId>(id),
            Name = name,
            Description = description,
            Cost = cost,
            AmountReward = amountReward,
            StartDate = start,
            DurationInHours = durationInHours,
            IsOpen = isOpen,
            MinLevel = minLevel,
            LossLimit = lossLimit
        };
    }
}
