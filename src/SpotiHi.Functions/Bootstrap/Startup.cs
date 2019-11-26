using Design.Promob.ProjectsApi.Data.Connections;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SpotiHi.Abstractions.Core.Interfaces.Services;
using SpotiHi.Abstractions.Data.Interfaces;
using SpotiHi.Core.Interfaces;
using SpotiHi.Data.Repositories;
using System;

[assembly: FunctionsStartup(typeof(SpotiHi.Functions.Bootstrap.Startup))]
namespace SpotiHi.Functions.Bootstrap
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<MongoDBConnection>(
                b => new MongoDBConnection(Environment.GetEnvironmentVariable("DatabaseConnectionString")));

            builder.Services.AddScoped<IPlaylistsRepository, PlaylistsRepository>();
            builder.Services.AddScoped<IPlaylistsService, PlaylistsService>();
        }
    }
}