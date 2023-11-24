﻿using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories;

internal class PredefinedQuery : IPredefinedQueries
{
    private readonly ClashRoyaleDbContext _context;

    public PredefinedQuery(ClashRoyaleDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<FirstQueryResponse>> FirstQuery()
    {
        //Consulta 1: Conocer los mejores jugadores que participan en una guerra.
        //Por cada clan que participa en una guerra obtener el jugador con más trofeos.

        var clanWars = _context.ClanWars
                        .Include(cw => cw.Clan)
                        .AsQueryable();

        var clanPlayer = _context.ClanPlayers
                            .Include(cp => cp.Clan)
                            .Include(cp => cp.Player)
                            .AsQueryable();

        var players = _context.Players.AsQueryable();

        var joinedTables = await (from cw in clanWars
                                  join cp in clanPlayer on cw.Clan!.Id equals cp.Clan!.Id
                                  join p in players on cp.Player!.Id equals p.Id
                                  select new
                                  {
                                      ClanId = cp.Clan!.Id,
                                      ClanName = cp.Clan!.Name,
                                      PlayerId = p.Id,
                                      PlayerName = p.Alias,
                                      Trophies = p.Elo
                                  }).ToListAsync();

        var result = from r in joinedTables
                     group r by r.ClanId into clanGroup
                     select clanGroup.MaxBy(t => t.Trophies);

        return result
             .Select(r => new FirstQueryResponse(r.PlayerId, r.PlayerName, r.Trophies, r.ClanId, r.ClanName))
             .ToList();
    }

    public async Task<IEnumerable<SecondQueryResponse>> SecondQuery()
    {
        //Consulta 2: Conocer el clan con mejor desempeño durante las guerras por región del mundo.
        //Por cada región obtener el clan con mayor cantidad de trofeos.

        var clans = await _context.Clans
                    .ToListAsync();

        var result = from c in clans
                     group c by c.Region into cRegion
                     select cRegion.MaxBy(t => t.TrophiesInWar);

        return result
            .Select(c => new SecondQueryResponse(c.Id, c.Name!, c.Region!, c.TrophiesInWar))
            .ToList();
    }

    public async Task<IEnumerable<ThirdQueryResponse>> ThirdQuery()
    {
        //Consulta 3: La carta o las cartas más donadas por región en el último mes.

        var donations = _context.Donations
                    .Include(d => d.Card)
                    .Include(d => d.Clan)
                    .AsQueryable();

        var lastMonthDate = DateTime.UtcNow.AddMonths(-1);
        var dateNow = DateTime.UtcNow;

        var sumCardsDonation = await (donations
            .Where(d => d.Date > lastMonthDate && d.Date < dateNow)
            .Select(d => new
            {
                ClanId = d.Clan!.Id,
                ClanRegion = d.Clan!.Region,
                CardId = d.Card!.Id,
                CardName = d.Card.Name,
                AmountCardDonated = d.Amount,
            })
            .GroupBy(d => new { d.ClanRegion, d.CardId, d.CardName })
            .Select(d => new
            {
                CardId = d.Key.CardId,
                Name = d.Key.CardName,
                Region = d.Key.ClanRegion,
                Sum = d.Sum(t => t.AmountCardDonated)
            }))
            .ToListAsync();

        var result = sumCardsDonation
            .GroupBy(d => d.Region)
            .Select(d => d.MaxBy(t => t.Sum));


        return result
            .Select(t => new ThirdQueryResponse(t!.CardId, t.Name!, t.Region!, t.Sum))
            .ToList();
    }

    public async Task<IEnumerable<FourthQueryResponse>> FourthQuery()
    {
        //Consulta 4: La carta más popular de cada tipo dentro de cada clan existente.
        //Hint: de cada jugador se conoce su carta favorita

        var clanPlayers = await _context.ClanPlayers
                                    .Include(cp => cp.Clan)
                                    .Include(cp => cp.Player)
                                    .ThenInclude(p => p!.FavoriteCard)
                                    .ToListAsync();


        var countFavoriteCard = from cp in clanPlayers
                                group cp by new
                                {
                                    ClanId = cp.Clan!.Id,
                                    CardId = cp.Player!.FavoriteCard!.Id,
                                    CardName = cp.Player!.FavoriteCard!.Name
                                } into cpc
                                let clanName = cpc.Where(r => r.Clan!.Id == cpc.Key.ClanId).First().Clan!.Name
                                select new
                                {
                                    ClanId = cpc.Key.ClanId,
                                    ClanName = clanName,
                                    CardId = cpc.Key.CardId,
                                    CardName = cpc.Key.CardName,
                                    Count = cpc.Count()
                                };

        var result = from cp in countFavoriteCard
                     group cp by cp.ClanId into cpc
                     select cpc.MaxBy(c => c.Count);


        return result
            .Select(c => new FourthQueryResponse(c.CardId, c.CardName, c.Count, c.ClanId, c.ClanName))
            .ToList();

    }

    public async Task<IEnumerable<FifthQueryResponse>> FifthQuery(int trophies)
    {
        //Consulta 5: Dado un jugador saber a qué clanes se puede unir,
        //conociendo los requisitos de cada clan.

        var result = _context.Clans
            .Where(c => c.TypeOpen && c.AmountMembers < 50 && c.MinTrophies < trophies);

        return await result
            .Select(r => new FifthQueryResponse(r.Id, r.Name!))
            .ToListAsync();
    }

    public async Task<IEnumerable<SixthQueryResponse>> SixthQuery()
    {
        //Consulta 6: Los desafíos donde haya participado al menos un jugador que lo haya completado.

        var playerChallenge = await _context.PlayerChallenges
                                    .Include(pc => pc.Player)
                                    .Include(pc => pc.Challenge)
                                    .ToListAsync();

        var result = from pc in playerChallenge
                     group pc by pc.Challenge!.Id into pChallengeId
                     where pChallengeId.Any(pCId => pCId.IsCompleted)
                     let name = pChallengeId.Where(pCId => pCId.Challenge!.Id == pChallengeId.Key)
                                            .Select(x => x.Challenge!.Name)
                                            .First()
                     select new
                     {
                         ChallengeId = pChallengeId.Key,
                         ChallengeName = name
                     };

        return result
            .Select(r => new SixthQueryResponse(r.ChallengeId, r.ChallengeName))
            .ToList();
    }

    public async Task<IEnumerable<SeventhQueryResponse>> SeventhQuery(int year)
    {
        var battles = _context.Battles
                        .AsQueryable();
        var result = from b in battles
                     where b.Date.Year == year
                     group b by b.Date.Month into gMonth
                     select new
                     {
                         Mount = gMonth.Key,
                         Amount = gMonth.Count()
                     };

        return await result
            .Select(r => new SeventhQueryResponse(r.Mount, r.Amount))
            .ToListAsync();

    }
}
