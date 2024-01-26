using ApiUser.Application.Dtos;
using ApiUser.Application.Interfaces.Mappers;
using ApiUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Application.Mappers
{
    public class UsersMapper : IUsersMapper
    {
        public Users? DtoToEntity(UsersDto? dto)
        {   
            if(dto != null)
            {
                return new Users()
                {
                    Id = dto.Id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                };
            }
            return null;
        }

        public UsersDto? EntityToDto(Users? entity)
        {   
            if(entity != null)
            {
                return new UsersDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                };
            }
            return null;
        }

        public IEnumerable<UsersDto> ListEntityToListDto(IEnumerable<Users> entities)
        {
            return entities.Select(x => new UsersDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            });
        }
    }
}
