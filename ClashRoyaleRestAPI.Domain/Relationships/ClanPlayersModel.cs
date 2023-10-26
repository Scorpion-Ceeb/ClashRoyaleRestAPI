﻿using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Domain.Relationships
{
    public class ClanPlayersModel
    {
        private ClanPlayersModel() { }
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

            return playerClan;
        }

        public void UpdateRank(RankClan rank)
        {
            Rank = rank;
        }
    }
}
