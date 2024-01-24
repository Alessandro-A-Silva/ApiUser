using ApiUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<bool> Create(Users entity);
        Task<bool> Update(Users entity);
        Task<bool> Delete(Users entity);
        Task<Users> Read(Users entity);
        Task<Users> ReadById(int id);
        Task<IEnumerable<Users>> ReadAll(Users Entity);
    }
}
