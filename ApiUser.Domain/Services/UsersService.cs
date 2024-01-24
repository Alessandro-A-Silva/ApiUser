using ApiUser.Domain.Entities;
using ApiUser.Domain.Interfaces.Repositorys;
using ApiUser.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepositry _userRepository;
        public UsersService(IUsersRepositry userRepository) => _userRepository = userRepository;

        public  async Task<bool> Create(Users entity)
        {
            if(_userRepository.ReadByEmail(entity.Email) == null)
                return await _userRepository.Create(entity);

            return await Task.FromResult(false);
        }

        public async Task<bool> Delete(Users entity)
        {
            return await _userRepository.Delete(entity);
        }

        public async Task<Users> Read(Users entity)
        {
            return await _userRepository.Read(entity);
        }

        public async Task<IEnumerable<Users>> ReadAll(Users Entity)
        {
            return await _userRepository.ReadAll(Entity);
        }

        public async Task<Users> ReadById(int id)
        {
            return await _userRepository.ReadById(id);
        }

        public async Task<bool> Update(Users entity)
        {
            return await _userRepository.Update(entity);
        }
    }
}
