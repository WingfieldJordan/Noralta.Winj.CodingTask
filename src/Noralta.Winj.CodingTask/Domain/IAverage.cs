namespace Noralta.Winj.CodingTask.Domain;

public interface IAverage
{
    public double Compute(int decimalPlaces = 0);
    public IAverage AddValue(double value);
    public int GetValuesCount();
}

public class Average : IAverage
{
    private readonly Dictionary<int, double> _data = new();
    
    public Average()
    {
    }

    public Average(List<double> values)
    {
        if (values.Count <= 0)
            return;
        
        foreach (var value in values)
        {
            _data.Add(_data.Count+1, value);
        }
    }

    public double Compute(int decimalPlaces = 0)
    {
        var averageValue = _data.Count > 0
            ? _data.Values.Average()
            : 0;
        
        return Math.Round(averageValue, decimalPlaces);
    }

    public IAverage AddValue(double value)
    {
        _data.Add(_data.Count+1, value);
        return this;
    }

    public int GetValuesCount()
    {
        return _data.Count;
    }
}