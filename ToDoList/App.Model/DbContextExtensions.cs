
using App.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Const = App.Common.Constants;

namespace GRP.Model;
public static class DbContextExtensions
{
    public static IServiceCollection AddDbContextGRP(this IServiceCollection services, IConfiguration configuration)
    {

        var BD_CON = configuration.GetConnectionString(Const.BD_CON);

        services.AddDbContext<TareasContext>(option => option.UseSqlServer(BD_CON));

        return services;
    }
}