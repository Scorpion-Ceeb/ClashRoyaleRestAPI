﻿using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models.Clan
{
    public class ClanModel : IEntity<int>
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Region { get; private set; }
        public bool TypeOpen { get; private set; }
        public int AmountMembers { get; private set; }
        public int TrophiesInWar { get; private set; }
        public int MinTrophies { get; private set; }
        public List<ClanPlayersModel>? Players { get; private set; }

        public void AddPlayer(PlayerModel player, RankClan rank = RankClan.Member)
        {
            Players ??= new List<ClanPlayersModel>();

            var playerClan = ClanPlayersModel.Create(player, this, rank);

            Players!.Add(playerClan);
        }

        public void AddAmountMember()
        {
            AmountMembers+=1;
        }
        public void RemoveAmountMember()
        {
            AmountMembers += 1;
        }
    }
}
