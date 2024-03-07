using LinkShortener.DTOS.UserDtos;
using LinkShortener.Entities;
using LinkShortener.UseCases.UserUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkShortener.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IAuthenticateUserService _authenticateUserService;
        private readonly IGetUserListService _userListService;
        private readonly IGetLinksService _getLinksService;
        public UserController(IRegisterUserService registerUserService, IAuthenticateUserService authenticateUserService, IGetUserListService getUserListService, IGetLinksService getLinksService)
        {
            _registerUserService = registerUserService;
            _authenticateUserService = authenticateUserService;
            _userListService = getUserListService;
            _getLinksService = getLinksService;

        }
        [HttpPost]
        [Route("registerUser")]
        public async Task<Response> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            return await _registerUserService.RegisterUser(registerUserDto);
        }

        [HttpPost]
        [Route("authenticateUser")]
        public async Task<Response> AuthenticateUser([FromBody] LoginDto loginDto)
        {
            return await _authenticateUserService.AuthenticateByUsername(loginDto.Username, loginDto.Password);
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<Response> GetUsers()
        {
            return await _userListService.GetUsers();
        }
        [HttpGet]
        [Route("getlinks/{idUser}")]
        public async Task<Response> GetUserLinks(int idUser)
        {
            return await _getLinksService.GetLinks(idUser);
        }

    }
}
