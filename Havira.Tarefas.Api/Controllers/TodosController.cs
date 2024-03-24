using Havira.Tarefas.Application.DTOs.Todos;
using Havira.Tarefas.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Havira.Tarefas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> Create(TodoCreateDto todoCreateDto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Usuario Invalido");
            }

            var todo = await _todoService.CreateTodoAsync(todoCreateDto, userId);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public async Task<IActionResult> GetAll()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Usuario Invalido");
            }

            var todos = await _todoService.GetTodosByUserIdAsync(userId);

            return Ok(todos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> GetById(Guid id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, TodoUpdateDto todoUpdateDto)
        {
            var updated = await _todoService.UpdateTodoAsync(id, todoUpdateDto);
            if (!updated) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _todoService.DeleteTodoAsync(id);

            if (!deleted) return NotFound();

            return Ok();
        }
    }
}
