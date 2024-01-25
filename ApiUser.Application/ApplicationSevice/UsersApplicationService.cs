using ApiUser.Application.Dtos;
using ApiUser.Application.Interfaces.ApplicationServices;
using ApiUser.Application.Interfaces.Mappers;
using ApiUser.Domain.Entities;
using ApiUser.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Application.ApplicationSevice
{
    public class UsersApplicationService : IUsersApplicationService
    {
        private readonly IUsersMapper _usersMapper;
        private readonly IUsersService _usersService;
        public UsersApplicationService(IUsersMapper usersMapper,IUsersService usersService)
        {
            _usersMapper = usersMapper;
            _usersService = usersService;
        }

        public async Task<bool> Create(Users entity)
        {
            return await _usersService.Create(entity);
        }

        public async Task<bool> Delete(Users entity)
        {
            return await _usersService.Delete(entity);
        }

        public async Task<UsersDto> Read(Users entity)
        {
            return _usersMapper.EntityToDto(await _usersService.Read(entity));
        }

        public async Task<IEnumerable<UsersDto>> ReadAll(Users entity)
        {
            return _usersMapper.ListEntityToListDto(await _usersService.ReadAll(entity));
        }

        public async Task<bool> Update(Users entity)
        {
            return await _usersService.Update(entity);
        }
    }
}
