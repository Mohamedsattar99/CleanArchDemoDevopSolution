using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users.Commands.DeleteUser.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserOutput>
    {
        private readonly IDemoDbContext context;
        
        public DeleteUserCommandHandler(IDemoDbContext legateDbContext)
        {
            context = legateDbContext;
        }
        public async Task<DeleteUserOutput> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FindAsync(request.Id);
            if(entity== null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), request.Id);
            }
            context.Users.Remove(entity);
           if(await context.SaveChangesAsync(cancellationToken)> 0)
            {
                return new DeleteUserOutput
                {
                    Success = true
                };
            }
            return new DeleteUserOutput
            {
                Success = false
            };
        }
    }
}
