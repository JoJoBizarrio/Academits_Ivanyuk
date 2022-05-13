namespace TemperatureTask.Scales
{
    internal class CelsiusScale : ITemperatureScale
    {
        public double ConvertToCelsius(double value)
        {
            return value;
        }

        public double ConvertFromCelsius(double value)
        {
            return value;
        }
    }
}