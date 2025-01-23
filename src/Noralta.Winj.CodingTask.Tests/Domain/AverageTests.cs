using FluentAssertions;
using Noralta.Winj.CodingTask.Domain;

namespace Noralta.Winj.CodingTask.Tests.Domain;

public class AverageTests
{
    [Fact]
    public void ShouldNotErrorOnEmpty()
    {
        var average = new Average();

        var exceptions = new List<Exception>();
        try
        {
            average.Compute();
        }
        catch (Exception e)
        {
            exceptions.Add(e);
        }

        exceptions.Count.Should().BeLessThanOrEqualTo(0);
    }

    [Fact]
    public void ShouldBeAbleToAddValues()
    {
        var average = new Average();
        var valuesToAdd = new List<double>
        {
            0.1,
            1.45,
            4509468,
            298.8823904832409,
            24.5,
            -45346.9,
            -423.09,
            -1,
            0
        };

        average.GetValuesCount().Should().Be(0);
        
        valuesToAdd.ForEach(v => average.AddValue(v));
        average.GetValuesCount().Should().Be(9);
    }
    
    [Fact]
    public void ShouldComputeAverage()
    {
        var average1 = new Average([
        ]);
        average1.Compute().Should().Be(0);
        average1.AddValue(45).Compute().Should().Be(45);
        average1.AddValue(-23).Compute().Should().Be(11);
        
        var average2 = new Average([
            0.1,
            1.45,
            4509468,
            298.8823904832409,
            24.5,
            -45346.9,
            -423.09,
            -1,
            0
        ]);
        average2.Compute().Should().Be(496002);
        average2.Compute(1).Should().Be(496002.4);
        average2.Compute(2).Should().Be(496002.44);
        average2.Compute(3).Should().Be(496002.438);
        average2.Compute(4).Should().Be(496002.4380);
        average2.Compute(5).Should().Be(496002.43804);
        average2.Compute(6).Should().Be(496002.438043);
        average2.Compute(7).Should().Be(496002.4380434);
        average2.Compute(8).Should().Be(496002.43804339);
        average2.Compute(9).Should().Be(496002.438043387);
        
        var average3 = new Average([
            -45.0,
            -4,
            -57404.09830495,
            -34,
            -4579.1
        ]);
        average3.Compute().Should().Be(-12413);
        average3.Compute(1).Should().Be(-12413.2);
        average3.Compute(2).Should().Be(-12413.24);
        average3.Compute(3).Should().Be(-12413.240);
        average3.Compute(4).Should().Be(-12413.2397);
        average3.AddValue(0).Compute().Should().Be(-10344);
        average3.Compute(1).Should().Be(-10344.4);
        average3.Compute(2).Should().Be(-10344.37);
        average3.Compute(3).Should().Be(-10344.366);
        average3.Compute(4).Should().Be(-10344.3664);
        average3.Compute(5).Should().Be(-10344.36638);

        var average4 = new Average([
            123.47349,
            576.23497
        ]);
        average4.Compute().Should().Be(350);
        average4.Compute(1).Should().Be(349.9);
        average4.Compute(2).Should().Be(349.85);
        average4.Compute(3).Should().Be(349.854);
        average4.Compute(4).Should().Be(349.8542);
        average4.Compute(5).Should().Be(349.85423);
    }
}