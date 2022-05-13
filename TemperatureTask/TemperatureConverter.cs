using TemperatureTask.Scales;

namespace TemperatureTask
{
    internal static class TemperatureConverter
    {
        public static double Convert(double value, ITemperatureScale inputScale, ITemperatureScale outputScale)
        {
            return outputScale.ConvertFromCelsius(inputScale.ConvertToCelsius(value));
        }
    }
}
