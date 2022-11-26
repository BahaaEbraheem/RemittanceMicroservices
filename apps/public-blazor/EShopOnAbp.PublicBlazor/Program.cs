using System;
using EShopOnAbp.CurrencyService.Currencies;
using EShopOnAbp.PublicBlazor;
//using EShopOnAbp.PublicBlazor.Data;

using Serilog;
using Serilog.Events;

namespace EShopOnAbp.PublicBlazor;

public class Program
{


    //public static async Task<int> Main(string[] args)
    //{
    //    var assemblyName = typeof(Program).Assembly.GetName().Name;

    //    SerilogConfigurationHelper.Configure(assemblyName);

    //    try
    //    {
    //        Log.Information($"Starting {assemblyName}.");
    //        var app = await ApplicationBuilderHelper.BuildApplicationAsync<PublicBlazorModule>(args);
    //        await app.InitializeApplicationAsync();
    //        await app.RunAsync();

    //        return 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Fatal(ex, $"{assemblyName} terminated unexpectedly!");
    //        return 1;
    //    }
    //    finally
    //    {
    //        Log.CloseAndFlush();
    //    }
    //}





    public async static Task<int> Main(string[] args)
    {
        var loggerConfiguration = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console());

        Log.Logger = loggerConfiguration.CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<PublicBlazorModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();

            Log.Information("Starting EShopOnAbp.PublicBlazor.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
            {
                throw;
            }

            Log.Fatal(ex, "EShopOnAbp.PublicBlazor terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}
