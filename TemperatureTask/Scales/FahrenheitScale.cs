namespace TemperatureTask.Scales
{
    internal class FahrenheitScale : ITemperatureScale
    {
        public double ConvertToCelsius(double value)
        {
            return (value - 32) / 1.8;
        }

        public double ConvertFromCelsius(double value)
        {
            return value * 9 / 5 + 32;
        }
    }
}
