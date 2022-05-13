using TemperatureTask.Scales;

namespace TemperatureTask
{
    internal static class TemperatureTaskMain
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ITemperatureScale[] scales = { new CelsiusScale(), new FahrenheitScale(), new KelvinScale() };

            TemperatureTaskForm temperatureTaskForm = new TemperatureTaskForm(scales);
            Application.Run(temperatureTaskForm);
        }
    }
}