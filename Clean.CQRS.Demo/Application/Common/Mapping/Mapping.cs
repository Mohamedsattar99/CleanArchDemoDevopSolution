using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>()
            .ReverseMap();
        }
    }
}
