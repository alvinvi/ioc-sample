using Microsoft.VisualStudio.TestTools.UnitTesting;
using ioc_sample;


namespace ioc_sample_tests;

[TestClass]
public class DefaultTimeSliceTests
{
    [TestMethod]
    public void Is_Instance_Type_DefaultTimeSlice()
    {
        var timeSlice = new DefaultTimeSlice();

        Assert.IsInstanceOfType(timeSlice, typeof(DefaultTimeSlice));
    }

    [TestMethod]
    public void Is_Instance_Type_ITimeSlice()
    {
        var timeSlice = new DefaultTimeSlice();

        Assert.IsInstanceOfType(timeSlice, typeof(ITimeSlice));
    }

    [TestMethod]
    public void Is_Instance_Type_ITransientTimeSlice()
    {
        var timeSlice = new DefaultTimeSlice();

        Assert.IsInstanceOfType(timeSlice, typeof(ITransientTimeSlice));
    }

    [TestMethod]
    public void Is_Instance_Type_IScopedTimeSlice()
    {
        var timeSlice = new DefaultTimeSlice();

        Assert.IsInstanceOfType(timeSlice, typeof(IScopedTimeSlice));
    }

    [TestMethod]
    public void Is_Instance_Type_ISingletonTimeSlice()
    {
        var timeSlice = new DefaultTimeSlice();

        Assert.IsInstanceOfType(timeSlice, typeof(ISingletonTimeSlice));
    }
}
