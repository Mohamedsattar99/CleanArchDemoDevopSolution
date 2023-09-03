using Application.Users.Queries.GetUserList.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList
{
    public class GetUsersListQuery: IRequest<UsersListDto>
    {
    }
}
