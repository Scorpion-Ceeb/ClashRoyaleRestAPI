﻿using ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.Relationships;

public class DonationModel : Entity<DonationId>
{
    private DonationModel()
    {
        Id = ValueObjectId.CreateUnique<DonationId>();
    }
    public PlayerModel? Player { get; private set; }
    public ClanModel? Clan { get; private set; }
    public CardModel? Card { get; private set; }
    public int Amount { get; private set; }
    public DateTime Date { get; private set; }

    public static DonationModel Create(PlayerModel player, ClanModel clan, CardModel card, int amount, DateTime date)
    {
        var donation =  new DonationModel
        {
            Player = player,
            Clan = clan,
            Card = card,
            Amount = amount,
            Date = date
        };

        donation.RaiseDomainEvent(new DonationCreatedDomainEvent(Guid.NewGuid(),
                                                                 clan.Id.Value,
                                                                 player.Id.Value,
                                                                 card.Id));

        return donation;
    }
}
