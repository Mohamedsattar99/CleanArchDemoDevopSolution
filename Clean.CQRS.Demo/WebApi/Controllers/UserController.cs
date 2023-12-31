﻿using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserDetails;
using Application.Users.Queries.GetUserList;
using Application.Users.Queries.GetUserList.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class UserController : BaseController
    {
       
        [HttpGet]
        public async Task<ActionResult<UserLookupDto>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDetailsVM>> Get([FromQuery]GetUserDetailQuery query)
        {
            var result= await Mediator.Send(query);
            return Ok(result);
        } 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddUser([FromBody]CreateUserCommand userCommand)
        {
           var result= await Mediator.Send(userCommand);
            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody]UpdateUserCommand userCommand)
        {
            var result = await Mediator.Send(userCommand);
            return Ok(result);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromQuery]DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }


    }
}
