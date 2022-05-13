namespace TemperatureTask.Scales
{
    internal interface ITemperatureScale
    {
        double ConvertToCelsius(double value);

        double ConvertFromCelsius(double value);
    }
}
