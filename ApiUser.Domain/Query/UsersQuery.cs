using ApiUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Domain.Query
{
    public static class UsersQuery
    {
        public static IQueryable<Users> FilterById(this IQueryable<Users> query, int? id)
        {
            if(id > 0)
                return query.Where(x => x.Id == id);

            return query;
        }

        public static IQueryable<Users> FilterByFirstName(this IQueryable<Users> query, string? firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
                return query.Where(x => x.FirstName == firstName);

            return query;
        }
        public static IQueryable<Users> FilterByLastName(this IQueryable<Users> query, string? lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
                return query.Where(x => x.LastName == lastName);

            return query;
        }
        public static IQueryable<Users> FilterByEmail(this IQueryable<Users> query, string? email)
        {
            if (!string.IsNullOrEmpty(email))
                return query.Where(x => x.Email == email);

            return query;
        }
        public static IQueryable<Users> FilterByPassword(this IQueryable<Users> query, string? password)
        {
            if (!string.IsNullOrEmpty(password))
                return query.Where(x => x.Password == password);

            return query;
        }
    }
}
