﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Battle;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

public record AddBattleCommand(BattleModel Battle, int WinnerId, int LoserId) : ICommand<Guid>;
