using System;
using System.Collections.Generic;
using BusinessLogic.Questions.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models.Questions;

namespace Questions.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionLogic _questionLogic;

        public QuestionController(IQuestionLogic questionLogic)
        {
            _questionLogic = questionLogic;
        }
    
        [HttpPost]
        public IActionResult Create([FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newQuestion = _questionLogic.Create(questionDto);

            return CreatedAtAction(nameof(GetById), new { questionEntityId = newQuestion.EntityId }, questionDto);
        }

        [HttpGet("{questionEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid questionEntityId)
        {
            var result = _questionLogic.GetById(questionEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{questionEntityId:guid}")]
        public IActionResult Update([FromBody] QuestionDto questionDto, [FromRoute] Guid questionEntityId)
        {
            var result = _questionLogic.Update(questionDto, questionEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{questionEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid questionEntityId)
        {
            var result = _questionLogic.Delete(questionEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<QuestionDto> GetAll()
        {
            var answers = _questionLogic.GetAll();

            return answers;
        }

    }
}
