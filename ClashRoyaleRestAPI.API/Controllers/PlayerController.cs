﻿using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddChallengeResult;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/players")]
public class PlayerController : ApiController
{
    private readonly IMapper _mapper;
    public PlayerController(IMediator sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET: api/players
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllModelQuery<PlayerModel, int>();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/players/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPlayerByIdFullLoadQuery(id, true);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/players/{alias}
    [HttpGet("{alias}")]
    public async Task<IActionResult> GetAllByAlias(string alias)
    {
        var query = new GetAllPlayerByAliasQuery(alias);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/players
    [HttpPost]
    public async Task<IActionResult> Post(AddPlayerRequest playerRequest)
    {
        var player = _mapper.Map<PlayerModel>(playerRequest);

        var command = new AddModelCommand<PlayerModel, int>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/players/{result.Value}", result.Value)
            : Problem(result.Errors);

    }

    // PUT api/players/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdatePlayerRequest playerRequest)
    {
        if (id != playerRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var player = _mapper.Map<PlayerModel>(playerRequest);

        var command = new UpdateModelCommand<PlayerModel, int>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // DELETE api/players/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var commandDelete = new DeleteModelCommand<PlayerModel, int>(id);

        var result = await _sender.Send(commandDelete);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET api/players/{id:int}/cards
    [HttpGet("{id:int}/cards")]
    public async Task<IActionResult> GetCards(int id)
    {
        var query = new GetAllCardOfPlayerQuery(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/players/{playerId:int}/cards/{cardId:int}
    [HttpPost("{playerId:int}/cards/{cardId:int}")]
    public async Task<IActionResult> AddCard(int playerId, int cardId)
    {
        var command = new AddCardCommand(playerId, cardId);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // PATCH api/players/{playerId:int}/{alias}
    [HttpPatch("{playerId:int}/{alias}")]
    public async Task<IActionResult> UpdateAlias(int playerId, string alias)
    {
        var query = new UpdatePlayerAliasCommand(playerId, alias);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok()
            : Problem(result.Errors);
    }

    // POST api/players/{playerId:int}/challenge
    [HttpPost("{playerId:int}/challenge")]
    public async Task<IActionResult> PostChallengeResult(int playerId, [FromBody] AddChallengeResultRequest addChallengeResult)
    {
        var command = new AddChallengeResultCommand(playerId, addChallengeResult.ChallengeId, addChallengeResult.Reward);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // POST api/players/{playerId:int}/donate
    [HttpPost("{playerId:int}/donate")]
    public async Task<IActionResult> MakeDonation(int playerId, [FromBody] AddDonationRequest addDonationRequest)
    {
        var command = new AddDonationCommand(
            playerId,
            addDonationRequest.ClanId,
            addDonationRequest.CardId,
            addDonationRequest.Amount);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

}
