using ioc_sample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc_sample_tests;

[TestClass]
public class TimeSliceDisplayTests
{
    [TestMethod]
    public void Is_Instance_Type_TimeSliceDisplay()
    {
        var timeSlices = new TimeSliceDisplay(null, null, null);

        Assert.IsInstanceOfType(timeSlices, typeof(TimeSliceDisplay));
    }

    [TestMethod]
    public void Is_Field_transcientTimeSlice_Null()
    {
        var timeSlices = new TimeSliceDisplay(null, null, null);

        var transcientTimeSlice = timeSlices.TransientTimeSlice;

        Assert.IsNull(transcientTimeSlice);
    }

    [TestMethod]
    public void Is_Field_scopedTimeSlice_Null()
    {
        var timeSlices = new TimeSliceDisplay(null, null, null);

        var scopedTimeSlice = timeSlices.ScopedTimeSlice;

        Assert.IsNull(scopedTimeSlice);
    }

    [TestMethod]
    public void Is_Field_singletonTimeSlice_Null()
    {
        var timeSlices = new TimeSliceDisplay(null, null, null);

        var singletonTimeSlice = timeSlices.SingletonTimeSlice;

        Assert.IsNull(singletonTimeSlice);
    }

    private IServiceProvider GetHostServiceProvider()
    {
        var host = DIUtils.BuildHost(new string[] { });
        var serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        return provider;
    }

    [TestMethod]
    public void Is_TimeSliceDisplay_Initialized()
    {
        var provider = GetHostServiceProvider();

        var timeSlices = provider.GetRequiredService<TimeSliceDisplay>();

        Assert.IsNotNull(timeSlices);
    }

    [TestMethod]
    public void Is_Field_transcientTimeSlice_NotNull()
    {
        var provider = GetHostServiceProvider();
        var timeSlices = provider.GetRequiredService<TimeSliceDisplay>();

        var transcientTimeSlice = timeSlices.TransientTimeSlice;

        Assert.IsNotNull(transcientTimeSlice);
    }

    [TestMethod]
    public void Is_Field_scopedTimeSlice_NotNull()
    {
        var provider = GetHostServiceProvider();
        var timeSlices = provider.GetRequiredService<TimeSliceDisplay>();

        var scopedTimeSlice = timeSlices.ScopedTimeSlice;

        Assert.IsNotNull(scopedTimeSlice);
    }

    [TestMethod]
    public void Is_Field_singletonTimeSlice_NotNull()
    {
        var provider = GetHostServiceProvider();
        var timeSlices = provider.GetRequiredService<TimeSliceDisplay>();

        var singletonTimeSlice = timeSlices.SingletonTimeSlice;

        Assert.IsNotNull(singletonTimeSlice);
    }

    [TestMethod]
    public void Are_TranscientTimeSlices_Same_Scope_Diff_Values_From_Multiple_TimeSlices()
    {
        var provider = GetHostServiceProvider();
        var timeSlices1 = provider.GetRequiredService<TimeSliceDisplay>();
        var timeSlices2 = provider.GetRequiredService<TimeSliceDisplay>();

        Assert.AreNotEqual(timeSlices1.TransientTimeSlice, timeSlices2.TransientTimeSlice);
    }

    [TestMethod]
    public void Are_ScopedTimeSlices_Same_Scope_Same_Values_From_Multiple_TimeSlices()
    {
        var provider = GetHostServiceProvider();
        var timeSlices1 = provider.GetRequiredService<TimeSliceDisplay>();
        var timeSlices2 = provider.GetRequiredService<TimeSliceDisplay>();

        Assert.AreEqual(timeSlices1.ScopedTimeSlice, timeSlices2.ScopedTimeSlice);
    }

    [TestMethod]
    public void Are_SingletonTimeSlices_Same_Scope_Same_Values_From_Multiple_TimeSlices()
    {
        var provider = GetHostServiceProvider();
        var timeSlices1 = provider.GetRequiredService<TimeSliceDisplay>();
        var timeSlices2 = provider.GetRequiredService<TimeSliceDisplay>();

        Assert.AreEqual(timeSlices1.SingletonTimeSlice, timeSlices2.SingletonTimeSlice);
    }

    [TestMethod]
    public void Are_TranscientTimeSlices_Diff_Scope_Diff_Values_From_Multiple_TimeSlices()
    {
        var host = DIUtils.BuildHost(new string[] { });

        var serviceScope1 = host.Services.CreateScope();
        var provider1 = serviceScope1.ServiceProvider;
        var timeSlices1 = provider1.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices2 = provider1.GetRequiredService<TimeSliceDisplay>();

        var serviceScope2 = host.Services.CreateScope();
        var provider2 = serviceScope2.ServiceProvider;
        var timeSlices3 = provider2.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices4 = provider2.GetRequiredService<TimeSliceDisplay>();

        Assert.AreNotEqual(timeSlices1.TransientTimeSlice, timeSlices3.TransientTimeSlice);
    }

    [TestMethod]
    public void Are_ScopedTimeSlices_Diff_Scope_Diff_Values_From_Multiple_TimeSlices()
    {
        var host = DIUtils.BuildHost(new string[] { });

        var serviceScope1 = host.Services.CreateScope();
        var provider1 = serviceScope1.ServiceProvider;
        var timeSlices1 = provider1.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices2 = provider1.GetRequiredService<TimeSliceDisplay>();

        var serviceScope2 = host.Services.CreateScope();
        var provider2 = serviceScope2.ServiceProvider;
        var timeSlices3 = provider2.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices4 = provider2.GetRequiredService<TimeSliceDisplay>();

        Assert.AreNotEqual(timeSlices1.ScopedTimeSlice, timeSlices3.ScopedTimeSlice);
    }

    [TestMethod]
    public void Are_SingletonTimeSlices_Diff_Scope_Same_Values_From_Multiple_TimeSlices()
    {
        var host = DIUtils.BuildHost(new string[] { });

        var serviceScope1 = host.Services.CreateScope();
        var provider1 = serviceScope1.ServiceProvider;
        var timeSlices1 = provider1.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices2 = provider1.GetRequiredService<TimeSliceDisplay>();

        var serviceScope2 = host.Services.CreateScope();
        var provider2 = serviceScope2.ServiceProvider;
        var timeSlices3 = provider2.GetRequiredService<TimeSliceDisplay>();
        //var timeSlices4 = provider2.GetRequiredService<TimeSliceDisplay>();

        Assert.AreEqual(timeSlices1.SingletonTimeSlice, timeSlices3.SingletonTimeSlice);
    }
}

