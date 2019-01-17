using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Gamification.Abstractions;
using Models.Gamification;
using Models.Gamification.Read;

namespace Gamification.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/gamification")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionLogic _sessionLogic;

        public SessionController(ISessionLogic sessionLogic)
        {
            _sessionLogic = sessionLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] SessionWriteDto sessionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSession = _sessionLogic.Create(sessionDto);

            return CreatedAtAction(nameof(GetById), new { sessionEntityId = newSession.Id }, sessionDto);
        }

        [HttpGet]
        public ICollection<SessionReadDto> GetAll()
        {
            var answers = _sessionLogic.GetAll();

            return answers;
        }

        [HttpGet("{sessionEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid sessionEntityId)
        {
            var result = _sessionLogic.GetById(sessionEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{sessionEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid sessionEntityId)
        {
            var result = _sessionLogic.Delete(sessionEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
