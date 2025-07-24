using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;
using WolverineTest;

var builder = Host.CreateDefaultBuilder();

builder.UseWolverine();

builder.ConfigureServices(s =>
{
    s.AddHostedService<BgPublisher>();
});

var app = builder.Build();

app.Run();

public record FailedPayment(Guid Id, decimal Amount);