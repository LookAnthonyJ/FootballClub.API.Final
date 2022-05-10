using FootballClub.Models.Models.Player;
using FootballClub.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;
        public PlayersController(IPlayerService service)
        {
            _service = service;
        }
        [HttpGet("/GetAllPlayers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PlayerBaseModel>))]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }

        [HttpGet("/GetPlayerById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerExtendedModel))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public async Task<IActionResult> Post([FromBody] PlayerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.Insert(model);
                return user != null
                    ? (IActionResult)CreatedAtRoute(nameof(GetById), user, user.Id)
                    : Conflict();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerBaseModel))]
        public async Task<IActionResult> Put(int id, [FromBody] PlayerUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                var result = await _service.Update(model);

                return result != null
                    ? (IActionResult)Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _service.Delete(id));
            }
            return BadRequest();
        }
    }
}
