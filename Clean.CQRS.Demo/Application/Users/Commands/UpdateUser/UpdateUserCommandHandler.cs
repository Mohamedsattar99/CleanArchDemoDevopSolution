using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users.Commands.DeleteUser.Dtos;
using Application.Users.Commands.UpdateUser.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserOutput>
    {
        private readonly IDemoDbContext context;
        private readonly IMapper mapper;
        public UpdateUserCommandHandler(IDemoDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<UpdateUserOutput> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }
            entity.Address = request.Address;
            entity.Name = request.Name;
            entity.Age = request.Age;
            entity.JoiningDate = request.JoiningDate;
            entity.Phone = request.Phone;
            entity.Postion = request.Postion;
            entity.salary = request.salary;
            context.Users.Update(entity);
            if (await context.SaveChangesAsync(cancellationToken) > 0)
            {
                return new UpdateUserOutput
                {
                    Success = true
                };
            }
            return new UpdateUserOutput
            {
                Success = false
            };
        }
    }
}
