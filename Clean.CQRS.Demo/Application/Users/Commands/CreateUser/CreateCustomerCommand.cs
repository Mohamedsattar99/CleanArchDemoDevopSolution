using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.CreateUser.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserOutput>
    {

        public int Id { get; set; }
        public string Name { set; get; }
        public int Age { set; get; }
        public int salary { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Postion { set; get; }
        public DateTime JoiningDate { set; get; }

    }
}
