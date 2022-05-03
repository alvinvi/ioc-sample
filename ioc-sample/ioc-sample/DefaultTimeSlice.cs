namespace ioc_sample;

public class DefaultTimeSlice : ITransientTimeSlice, IScopedTimeSlice, ISingletonTimeSlice
{
    public DateTime DateTimePoint { get; } = DateTime.Now;
}
