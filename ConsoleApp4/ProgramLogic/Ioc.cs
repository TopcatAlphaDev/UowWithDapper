using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Autofac;
using UowWithRepository.Repositories;

namespace UowWithRepository.ProgramLogic
{
    public class Ioc
    {
        private static readonly string ConnectionString = $@"data source=localhost;initial catalog=ShoppingCenter;integrated security=true;persist security info=True;";
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(executingAssembly).AsImplementedInterfaces().Except<BaseRepository>();
            builder.RegisterType<SqlConnection>().WithParameter("connectionString", ConnectionString).As<IDbConnection>();
            return builder.Build();
        }

    }
}
