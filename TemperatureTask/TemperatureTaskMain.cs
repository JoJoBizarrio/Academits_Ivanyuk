namespace TemperatureTask
{
    internal static class TemperatureTaskMain
    {
        public const double KelvinConversionFactor = 273.15;
        public const double FarengeitConversionFactor = 32;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TemperatureTaskForm());
        }

        public static double GetConvertedCelsiusToKelvin(double celsius)
        {
            return celsius + KelvinConversionFactor;
        }

        public static double GetConvertedCelsiusToFahrenheit(double celsius)
        {
            return celsius * 9.0 / 5 + FarengeitConversionFactor;
        }

        public static double GetConvertedKelvinToCelsius(double kelvin)
        {
            return kelvin - KelvinConversionFactor;
        }

        public static double GetConvertedKelvinToFahrenheit(double kelvin)
        {
            return (kelvin - KelvinConversionFactor) * 9.0 / 5 + FarengeitConversionFactor;
        }

        public static double GetConvertedFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - FarengeitConversionFactor) * 5.0 / 9;
        }

        public static double GetConvertedFahrenheitToKelvin(double fahrenheit)
        {
            return (fahrenheit - FarengeitConversionFactor) * 5.0 / 9 + KelvinConversionFactor;
        }
    }
}