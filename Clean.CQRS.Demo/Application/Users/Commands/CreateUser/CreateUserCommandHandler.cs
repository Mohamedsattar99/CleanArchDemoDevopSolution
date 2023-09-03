using Application.Common.Interfaces;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserOutput>
    {
        private readonly IDemoDbContext context;
        private readonly IMapper mapper;
        public CreateUserCommandHandler(IDemoDbContext legateDb, IMapper _mapper)
        {
            context = legateDb;
            mapper = _mapper;
        }
        public async Task<CreateUserOutput> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            //var entity = new Domain.Entities.User()
            //{
            //    Id = request.Id,
            //    Name = request.Name,
            //    Address = request.Address,
            //    Age = request.Age,
            //    salary = request.salary,
            //    Postion = request.Postion,
            //    JoiningDate = DateTime.Parse(request.JoiningDate),
            //    Phone = request.Phone,
            //};
            var entity = mapper.Map<Domain.Entities.User>(request);
            context.Users.Add(entity);
           if(await context.SaveChangesAsync(cancellationToken)> 0)
            {
                return new CreateUserOutput
                {
                    Id = entity.Id,
                    Success=true
                };
            }
            return new CreateUserOutput
            {
                Success = false
            };
        }
    }
}
