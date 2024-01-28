using ApiUser.Domain.Entities;
using ApiUser.Domain.Interfaces.Repositorys;
using ApiUser.Domain.Query;
using Microsoft.EntityFrameworkCore;

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
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(Users entity)
        {
            try
            {
                _context.users.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<Users?> Read(Users? entity)
        {   
            if(entity != null)
            {
                return await _context.users.FilterById(entity.Id)
                                           .FilterByFirstName(entity.FirstName)
                                           .FilterByLastName(entity.LastName)
                                           .FilterByEmail(entity.Email)
                                           .FilterByPassword(entity.Password)
                                           .FirstOrDefaultAsync();
            }
            return null;
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

        public async Task<Users?> ReadByEmail(string? email)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Users?> ReadById(int id)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Users entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
