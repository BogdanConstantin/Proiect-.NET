using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Gamification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Gamification.Read;
using Models.Gamification.Write;

namespace Gamification.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/gamification/{sessionEntityId:guid}/answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerLogic _answerLogic;

        public AnswerController(IAnswerLogic answerLogic)
        {
            _answerLogic = answerLogic;
        }

        [HttpPost]
        public IActionResult Create([FromRoute] Guid sessionEntityId, [FromBody] AnswerWriteDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAnswer = _answerLogic.Create(sessionEntityId, answerDto);

            if (newAnswer == null)
            {
                return BadRequest("Invalid question.");
            }

            return CreatedAtAction(nameof(GetById), new { answerEntityId = newAnswer.Id }, answerDto);
        }

        [HttpGet("{answerEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid answerEntityId)
        {
            var result = _answerLogic.GetById(answerEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<AnswerReadDto> GetAll([FromRoute] Guid sessionEntityId)
        {
            var answers = _answerLogic.GetAll(sessionEntityId);

            return answers;
        }

        [HttpDelete("{answerEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid answerEntityId)
        {
            var result = _answerLogic.Delete(answerEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}