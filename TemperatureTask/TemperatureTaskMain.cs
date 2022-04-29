namespace TemperatureTask
{
    internal static class TemperatureTaskMain
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TemperatureTaskForm());
        }
    }
}