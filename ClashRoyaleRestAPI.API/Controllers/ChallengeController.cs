﻿using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetAllOpen;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/challenges")]
public class ChallengeController : ApiController
{
    private readonly IMapper _mapper;
    public ChallengeController(IMediator sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET api/challenges/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var quey = new GetModelByIdQuery<ChallengeModel, int>(id);

        var result = await _sender.Send(quey);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/challenges/open
    [HttpGet("open")]
    public async Task<IActionResult> GetAllOpenChallenges()
    {
        var query = new GetAllOpenChallengeQuery();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/challenges
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddChallengeRequest challengeRequest)
    {
        var challenge = _mapper.Map<ChallengeModel>(challengeRequest);

        var command = new AddModelCommand<ChallengeModel, int>(challenge);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/challenges/{result.Value}", result.Value) :
            Problem(result.Errors);
    }

    // PUT api/challenges/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateChallengeRequest challengeRequest)
    {
        if (id != challengeRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var challenge = _mapper.Map<ChallengeModel>(challengeRequest);

        var command = new UpdateModelCommand<ChallengeModel, int>(challenge);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/challenges/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteModelCommand<ChallengeModel, int>(id);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
