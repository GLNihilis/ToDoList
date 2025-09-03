using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interface
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todoModel);
        Task<Todo?> UpdateAsync(int id, UpdateTodoRequestDto updateDto);
        Task<Todo?> DeleteAsync(int id);
    }
}