using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList.Dtos
{
    public class UsersListDto
    {
        public IList<UserLookupDto> Users { set; get; }
    }
}
