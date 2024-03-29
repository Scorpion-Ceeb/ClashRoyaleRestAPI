﻿using ClashRoyaleRestAPI.Domain.DomainEvents.ClanDomainEvents;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using System.Text.Json.Serialization;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class ClanPlayersModel : Entity<ClanPlayersId>
{
    private ClanPlayersModel()
    {
        Id = ValueObjectId.CreateUnique<ClanPlayersId>();
    }

    [JsonIgnore]
    public ClanModel? Clan { get; private set; }
    public PlayerModel? Player { get; private set; }
    public RankClan Rank { get; private set; }

    public static ClanPlayersModel Create(PlayerModel player, ClanModel clan, RankClan rank)
    {
        var playerClan = new ClanPlayersModel()
        {
            Player = player,
            Clan = clan,
            Rank = rank
        };

        playerClan.RaiseDomainEvent(new ClanPlayerCreatedDomainEvent(Guid.NewGuid(),
                                                                     clan.Id.Value,
                                                                     player.Id.Value));

        return playerClan;
    }

    public void UpdateRank(RankClan rank)
    {
        Rank = rank;

        RaiseDomainEvent(new PlayerRankUpdatedDomainEvent(Guid.NewGuid(), Clan!.Id.Value, Player!.Id.Value, rank));
    }
}
