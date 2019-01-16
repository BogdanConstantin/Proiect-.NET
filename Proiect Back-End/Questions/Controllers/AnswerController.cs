using System;
using System.Collections.Generic;
using BusinessLogic.Questions.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models.Questions;

namespace Questions.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerLogic _answerLogic;

        public AnswerController(IAnswerLogic answerLogic)
        {
            _answerLogic = answerLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AnswerDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCourse = _answerLogic.Create(answerDto);

            return CreatedAtAction(nameof(GetById), new { answerEntityId = newCourse.EntityId }, answerDto);
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

        [HttpPut("{answerEntityId:guid}")]
        public IActionResult Update([FromBody] AnswerDto answerDto, [FromRoute] Guid answerEntityId)
        {
            var result = _answerLogic.Update(answerDto, answerEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
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

        [HttpGet]
        public ICollection<AnswerDto> GetAll()
        {
            var answers = _answerLogic.GetAll();

            return answers;
        }
    }
}
