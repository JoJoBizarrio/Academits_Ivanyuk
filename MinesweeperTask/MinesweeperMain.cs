using System.Drawing;

namespace MinesweeperTask
{
    internal static class MinesweeperMain
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MinesweeperUI());

            Point[] points =
            {
                new Point(10, 20),
                new Point(10, 40)
            };

            
        }

       
    }
}