using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ioc_sample;

static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    TimeSliceDisplay display = provider.GetRequiredService<TimeSliceDisplay>();
    display.DisplayTimeSlices($"{scope}-Call 1 .GetRequiredService<TimeSliceDisplay>()");

    Console.WriteLine();

    display = provider.GetRequiredService<TimeSliceDisplay>();
    display.DisplayTimeSlices($"{scope}-Call 2 .GetRequiredService<TimeSliceDisplay>()");

    Console.WriteLine();
    Console.WriteLine("-----------------------");

}


IHost host = DIUtils.BuildHost(args);

ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");


await host.RunAsync();