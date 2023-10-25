﻿using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Application.Battle.Command.AddBattle;
using ClashRoyaleRestAPI.Application.Battle.Queries.GetAllBattleInclude;
using ClashRoyaleRestAPI.Application.Battle.Queries.GetBattleByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/battles")]
    public class BattleController : ApiController
    {
        private readonly IMapper _mapper;
        public BattleController(ISender sender, IMapper mapper) : base(sender)
        {
            _mapper = mapper;
        }

        // GET: api/battles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBattleIncludeQuery();

            var result = await _sender.Send(query);

            return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
        }

        // GET api/battles/{battleId:Guid}
        [HttpGet("{battleId:Guid}")]
        public async Task<IActionResult> Get(Guid battleId)
        {
            var query = new GetBattleByIdFullLoadQuery(battleId, true);

            var result = await _sender.Send(query);

            return result.IsSuccess ?
                Ok(result.Value)
                : Problem(result.Errors);
        }

        // POST api/battles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBattleRequest battleRequest)
        {
            var battle = _mapper.Map<BattleModel>(battleRequest);

            var command = new AddBattleCommand(battle, battleRequest.WinnerId, battleRequest.LoserId);

            var result = await _sender.Send(command);

            return result.IsSuccess ?
                Created($"api/battles/{battle.Id.Value}", battle.Id.Value)
                : Problem(result.Errors);
        }
    }
}
