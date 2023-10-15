﻿using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Common.Relationships;

namespace ClashRoyaleRestAPI.Domain.Models.Clan
{
    public class ClanModel : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Region { get; set; }
        public bool TypeOpen { get; set; }
        public int AmountMembers { get; set; }
        public int TrophiesInWar { get; set; }
        public int MinTrophies { get; set; }
        public List<ClanPlayersModel>? Players { get; set; }
    }
}
