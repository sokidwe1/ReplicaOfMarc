using Business.Abstractions;
using Business.Implementations;
using NLog;
using NLog.Web;
using Training2.Extensions;
using Training2.Middlewares;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    logger.Debug("Initializing application...");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddRepositories(builder.Configuration);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddTransient<IClientEngine, ClientEngine>();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseMiddleware<GlobalExceptionHandler>();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex,"Program Has Stopped Because Their Was An Exception");
    throw (ex);

}
finally
{
    NLog.LogManager.Shutdown();
}
