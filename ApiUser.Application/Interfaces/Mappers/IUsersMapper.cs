using ApiUser.Application.Dtos;
using ApiUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Application.Interfaces.Mappers
{
    public interface IUsersMapper
    {
        Users? DtoToEntity(UsersDto? dto);
        UsersDto? EntityToDto(Users? entity);
        IEnumerable<UsersDto> ListEntityToListDto(IEnumerable<Users> entities);
    }
}
