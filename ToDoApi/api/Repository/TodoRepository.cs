using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDBContext _dBcontext;
        public TodoRepository(ApplicationDBContext dBcontext)
        {
            _dBcontext = dBcontext;
        }
        public async Task<Todo> CreateAsync(Todo todoModel)
        {
            await _dBcontext.Todos.AddAsync(todoModel);
            await _dBcontext.SaveChangesAsync();
            return todoModel;
        }

        public async Task<Todo?> DeleteAsync(int id)
        {
            var todoModel = await _dBcontext.Todos.FirstOrDefaultAsync(t => t.Id == id);

            if (todoModel == null)
            {
                return null;
            }

            _dBcontext.Todos.Remove(todoModel);
            await _dBcontext.SaveChangesAsync();
            return todoModel;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _dBcontext.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _dBcontext.Todos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Todo?> UpdateAsync(int id, UpdateTodoRequestDto updateDto)
        {
            var todoModel = await _dBcontext.Todos.FirstOrDefaultAsync(t => t.Id == id);

            if (todoModel == null)
            {
                return null;
            }

            todoModel.Title = updateDto.Title;
            todoModel.IsDone = updateDto.IsDone;

            await _dBcontext.SaveChangesAsync();
            return todoModel;
        }
    }
}