namespace TemperatureTask
{
    internal class TempretureTaskLogic
    {
        public const double KelvinConversionConstant = 273.15;
        public const double FarengeitConversionConstant = 32;

        public string[] Scales = new string[]
        {
            "Celsius",
            "Kelvin",
            "Fahrenheit"
        };

        private static double GetKelvinFromCelsius(double celsius)
        {
            return celsius + KelvinConversionConstant;
        }

        private static double GetFahrenheitFromCelsius(double celsius)
        {
            return celsius * 9.0 / 5 + FarengeitConversionConstant;
        }

        private static double GetCelsiusFromFahrenheit(double fahrenheit)
        {
            return (fahrenheit - FarengeitConversionConstant) * 5.0 / 9;
        }

        private static double GetCelsiusFromKelvin(double kelvin)
        {
            return kelvin - KelvinConversionConstant;
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