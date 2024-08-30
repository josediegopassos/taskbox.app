using AutoMapper;
using TaskBox.Application.DTOs;
using TaskBox.Domain.Models;

namespace TaskBox.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Domain.Models.Task, TaskDto>();
            CreateMap<Domain.Models.Task, RegisterTaskDto>();            
            CreateMap<ListTask, ListTaskDto>();
            CreateMap<User, UserDto>();
        }
    }
}
