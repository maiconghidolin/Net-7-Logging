using Enrichers;
using Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

{
    var host = builder.Host;

    host.UseSerilog((context, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration));

    var services = builder.Services;

    services.AddControllers();

    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen();

}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogEnricher.EnrichFromRequest);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<MiddlewareException>();

app.MapControllers();


app.Run();