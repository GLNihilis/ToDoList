using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _dBcontext;
        private readonly ITodoRepository _todoRepository;
        public TodoController(ApplicationDBContext dBcontext, ITodoRepository todoRepository)
        {
            _dBcontext = dBcontext;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoRepository.GetAllAsync();
            var todoDto = todos.Select(t => t.MakeTodoDto()).ToList();
            return Ok(todoDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo.MakeTodoDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequestDto createDto)
        {
            var todoModel = createDto.CreateTodoDto();
            await _todoRepository.CreateAsync(todoModel);
            // return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.MakeTodoDto());
            return Ok(todoModel.MakeTodoDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequestDto updateDto)
        {
            var todoModel = await _todoRepository.UpdateAsync(id, updateDto);

            if (todoModel == null)
            {
                return NotFound();
            }

            return Ok(todoModel.MakeTodoDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var todoModel = await _todoRepository.DeleteAsync(id);

            if (todoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}