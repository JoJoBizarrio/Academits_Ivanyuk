namespace TemperatureTask
{
    internal class TempretureTaskLogic
    {
        public const double KelvinConversionFactor = 273.15;
        public const double FarengeitConversionFactor = 32;

        public string[] Scales = new string[] { "Celsius", "Kelvin", "Fahrenheit" };

        private static double GetKelvinFromCelsius(double celsius)
        {
            return celsius + KelvinConversionFactor;
        }

        private static double GetFahrenheitFromCelsius(double celsius)
        {
            return celsius * 9.0 / 5 + FarengeitConversionFactor;
        }

        private static double GetCelsiusFromFahrenheit(double fahrenheit)
        {
            return (fahrenheit - FarengeitConversionFactor) * 5.0 / 9;
        }

        private static double GetCelsiusFromKelvin(double kelvin)
        {
            return kelvin - KelvinConversionFactor;
        }

        private static double GetKelvinFromFahrenheit(double fahrenheit)
        {
            return GetKelvinFromCelsius(GetCelsiusFromFahrenheit(fahrenheit));
        }

        private static double GetFahrenheitFromKelvin(double kelvin)
        {
            return GetFahrenheitFromCelsius(GetCelsiusFromKelvin(kelvin));
        }

        public double GetConvetedTemperature(string from, string to, double temperature)
        {
            if (from == Scales[0] && to == Scales[1])
            {
                return GetKelvinFromCelsius(temperature);
            }

            if (from == Scales[0] && to == Scales[2])
            {
                return GetFahrenheitFromCelsius(temperature);
            }

            if (from == Scales[1] && to == Scales[0])
            {
                return GetCelsiusFromKelvin(temperature);
            }

            if (from == Scales[1] && to == Scales[2])
            {
                return GetFahrenheitFromKelvin(temperature);
            }

            if (from == Scales[2] && to == Scales[0])
            {
                return GetCelsiusFromFahrenheit(temperature);
            }

            if (from == Scales[2] && to == Scales[1])
            {
                return GetKelvinFromFahrenheit(temperature);
            }

            return temperature;
        }
    }
}
