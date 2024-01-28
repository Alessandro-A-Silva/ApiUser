using ApiUser.Domain.Interfaces.Repositorys;
using ApiUser.Domain.Interfaces.Services;
using ApiUser.Domain.Services;
using ApiUser.Application.Interfaces.ApplicationServices;
using ApiUser.Application.Interfaces.Mappers;
using ApiUser.Application.ApplicationSevice;
using ApiUser.Application.Mappers;
using ApiUser.Infrastructure.Data.Repositorys;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<UsersRepository>().As<IUsersRepositry>();
            builder.RegisterType<UsersApplicationService>().As<IUsersApplicationService>();
            builder.RegisterType<UsersMapper>().As<IUsersMapper>();

            #endregion
        }
    }
}
