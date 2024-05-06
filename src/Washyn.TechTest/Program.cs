using Serilog;
using Serilog.Events;
using Volo.Abp.Data;
using Washyn.TechTest.Data;

namespace Washyn.TechTest;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host
                .UseAutofac();
            
            await builder.AddApplicationAsync<ProjectModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            

            Log.Information("Starting Project.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Project terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}