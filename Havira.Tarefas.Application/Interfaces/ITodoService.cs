﻿using Havira.Tarefas.Application.DTOs.Todos;
using Havira.Tarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havira.Tarefas.Application.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> CreateTodoAsync(TodoCreateDto todoDto, Guid userId);
        Task<IEnumerable<Todo>> GetTodosByUserIdAsync(Guid userId);
        Task<Todo> GetTodoByIdAsync(Guid id);
        Task<bool> UpdateTodoAsync(Guid id, TodoUpdateDto todoDto);
        Task<bool> DeleteTodoAsync(Guid id);
    }
}