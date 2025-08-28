using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controller;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto MakeTodoDto(this Todo todoModel)
        {
            return new TodoDto
            {
                Id = todoModel.Id,
                Title = todoModel.Title,
                IsDone = todoModel.IsDone
            };
        }

        public static Todo CreateTodoDto(this CreateTodoRequestDto createDto)
        {
            return new Todo
            {
                Title = createDto.Title,
                IsDone = createDto.IsDone
            };
        }
    }
}