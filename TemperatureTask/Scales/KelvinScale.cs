namespace TemperatureTask.Scales
{
    internal class KelvinScale : ITemperatureScale
    {
        public double ConvertToCelsius(double value)
        {
            return value - 273.15;
        }

        public double ConvertFromCelsius(double value)
        {
            return value + 273.15;
        }

        public override string ToString()
        {
            return "Kelvin";
        }
    }
}