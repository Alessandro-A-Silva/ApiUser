using ApiUser.Application.Dtos;
using ApiUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Application.Interfaces.ApplicationServices
{
    public interface IUsersApplicationService
    {
        Task<bool> Create(Users entity);
        Task<bool> Update(Users entity);
        Task<bool> Delete(Users entity);
        Task<IEnumerable<UsersDto>> ReadAll(Users entity);
        Task<UsersDto?> Read(Users entity);

    }
}
