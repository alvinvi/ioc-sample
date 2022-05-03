using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ioc_sample;

static internal class DIUtils
{
    static IHost? _host = null;

    static public IHost BuildHost(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
                        .ConfigureServices((_, services) =>
                            services.AddTransient<ITransientTimeSlice, DefaultTimeSlice>()
                                .AddScoped<IScopedTimeSlice, DefaultTimeSlice>()
                                .AddSingleton<ISingletonTimeSlice, DefaultTimeSlice>()
                                .AddTransient<TimeSliceDisplay>()
                        ).Build();

        _host = host;
        return _host;
    }


}
