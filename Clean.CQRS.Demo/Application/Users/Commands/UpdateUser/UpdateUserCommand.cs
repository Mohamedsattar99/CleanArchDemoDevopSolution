using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users.Commands.UpdateUser.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest<UpdateUserOutput>
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
