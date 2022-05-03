using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc_sample;

public class TimeSliceDisplay
{
    private readonly ITransientTimeSlice _transientTimeSlice;
    private readonly IScopedTimeSlice _scopedTimeSlice;
    private readonly ISingletonTimeSlice _singletonTimeSlice;

    public TimeSliceDisplay(ITransientTimeSlice transientTimeSlice, IScopedTimeSlice scopedTimeSlice, ISingletonTimeSlice singletonTimeSlice)
    {
        _transientTimeSlice = transientTimeSlice;
        _scopedTimeSlice = scopedTimeSlice;
        _singletonTimeSlice = singletonTimeSlice;
    }

    protected internal ITransientTimeSlice TransientTimeSlice { get { return _transientTimeSlice; } } 
    protected internal IScopedTimeSlice ScopedTimeSlice { get { return _scopedTimeSlice; } }
    protected internal ISingletonTimeSlice SingletonTimeSlice { get { return _singletonTimeSlice; } } 

    public void DisplayTimeSlices(string scope)
    {
        Console.WriteLine($"{scope}: {"Transient", -19} {_transientTimeSlice.DateTimePoint.ToOADate()}");
        Console.WriteLine($"{scope}: {"Scoped",-19} {_scopedTimeSlice.DateTimePoint.ToOADate()}");
        Console.WriteLine($"{scope}: {"Singleton",-19} {_singletonTimeSlice.DateTimePoint.ToOADate()}");
    }
}
