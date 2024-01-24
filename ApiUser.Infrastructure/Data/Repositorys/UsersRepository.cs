using ApiUser.Domain.Entities;
using ApiUser.Domain.Interfaces.Repositorys;
using ApiUser.Domain.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Infrastructure.Data.Repositorys
{
    public class UsersRepository : IUsersRepositry
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context) => _context = context;

        public async Task<bool> Create(Users entity)
        {
            try
            {
                _context.users.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Users entity)
        {
            try
            {
                _context.users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Users> Read(Users entity)
        {
            return await _context.users.FilterById(entity.Id)
                                       .FilterByFirstName(entity.FirstName)
                                       .FilterByLastName(entity.LastName)
                                       .FilterByEmail(entity.Email)
                                       .FilterByPassword(entity.Password)
                                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> ReadAll(Users entity)
        {
            return await _context.users.FilterById(entity.Id)
                                       .FilterByFirstName(entity.FirstName)
                                       .FilterByLastName(entity.LastName)
                                       .FilterByEmail(entity.Email)
                                       .FilterByPassword(entity.Password)
                                       .ToListAsync();
        }

        public async Task<Users> ReadByEmail(string email)
        {
            return await _context.users.FilterByEmail(email).FirstOrDefaultAsync();
        }

        public async Task<Users> ReadById(int id)
        {
            return await _context.users.FilterById(id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Users entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
