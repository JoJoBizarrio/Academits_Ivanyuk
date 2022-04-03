namespace TemperatureTask
{
    internal static class TemperatureTaskMain
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
            Application.Run(new TemperatureTaskForm());
        }
    }
}



//������ Temperature. ������� ��������� �� Swing  / Windows Forms ��� �������� ����������� �� ����� ����� � ������.
//������, ������ ��� ������� ������: 1-15, 21-22.
//����������� ����������������:
//1.	���� ����������� � ���� �����
//2.	������ ���� ������, ������� ��������� ����������� �� ����� ����� � ������
//3.	��������� �������� ������ ���������� �� �����, ��� ���� ���� �� �������������
//4.	����� ������ �� ����� ����� � � ����� ����������
//5.	��������� �����: �������, ����������, ��������
//6.	���� ����� �� �����, �� ����� ������� ������
//7.	����������� ������������ layout manager��