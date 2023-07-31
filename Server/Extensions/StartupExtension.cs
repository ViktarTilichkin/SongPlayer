using MySqlConnector;
using Server.Repository;
using Server.Service;

namespace Server.Extensions
{
    public static class StartupExtension
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(_ => new MySqlConnection(connectionString));
            services.AddTransient<UsersRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<UsersService>();
            services.AddTransient<AccountService>();
            //services.AddTransient<FileService>();
            //services.AddTransient<PlayerService>();
        }
    }
}
