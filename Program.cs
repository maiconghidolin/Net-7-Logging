using Enrichers;
using Extensions;
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

// can use like that
//app.UseMiddleware<ExceptionMiddleware>();

// or can use a extension method
app.UseExceptionMiddleware();

app.MapControllers();


app.Run();