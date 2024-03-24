using AutoMapper;
using Havira.Tarefas.Application.DTOs.Responses;
using Havira.Tarefas.Domain.Entities;

namespace Havira.Tarefas.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoReadDto>();
        }
    }
}
