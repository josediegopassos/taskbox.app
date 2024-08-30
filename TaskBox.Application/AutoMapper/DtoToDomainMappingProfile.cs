using AutoMapper;
using TaskBox.Application.DTOs;
using TaskBox.Domain.Models;

namespace TaskBox.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<TaskDto, Domain.Models.Task> ();
            CreateMap<RegisterTaskDto, Domain.Models.Task>();            
            CreateMap<ListTaskDto, ListTask>();
            CreateMap<UserDto, User>();
        }
    }
}
