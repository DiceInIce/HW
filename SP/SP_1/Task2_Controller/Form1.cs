using System.Runtime.InteropServices;

namespace Task2_Controller;

public partial class Form1 : Form
{
    private const int WM_SETTEXT = 0x000C;
    private const int WM_CLOSE = 0x0010;
    private const int WM_SYSCOMMAND = 0x0112;
    private const int SC_MINIMIZE = 0xF020;

    private string _currentTitle = "Task2 Main Window";

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern nint FindWindow(string? lpClassName, string? lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern nint SendMessage(nint hWnd, uint msg, nint wParam, string? lParam);

    [DllImport("user32.dll")]
    private static extern nint SendMessage(nint hWnd, uint msg, nint wParam, nint lParam);

    public Form1()
    {
        InitializeComponent();
    }

    private nint FindTargetWindow()
    {
        var hWnd = FindWindow(null, _currentTitle);
        if (hWnd != nint.Zero)
        {
            return hWnd;
        }

        const string defaultTitle = "Task2 Main Window";
        if (_currentTitle != defaultTitle)
        {
            hWnd = FindWindow(null, defaultTitle);
        }

        return hWnd;
    }

    private void changeTitleButton_Click(object sender, EventArgs e)
    {
        var hWnd = FindTargetWindow();
        if (hWnd == nint.Zero)
        {
            MessageBox.Show("Окно Task2_MainWindow не найдено. Сначала запустите его.", "Ошибка");
            return;
        }

        var newTitle = string.IsNullOrWhiteSpace(titleTextBox.Text)
            ? "Новый заголовок от контроллера"
            : titleTextBox.Text;

        SendMessage(hWnd, WM_SETTEXT, nint.Zero, newTitle);
        _currentTitle = newTitle;
    }

    private void closeWindowButton_Click(object sender, EventArgs e)
    {
        var hWnd = FindTargetWindow();
        if (hWnd == nint.Zero)
        {
            MessageBox.Show("Окно Task2_MainWindow не найдено. Сначала запустите его.", "Ошибка");
            return;
        }

        SendMessage(hWnd, WM_CLOSE, nint.Zero, nint.Zero);
    }

    private void minimizeWindowButton_Click(object sender, EventArgs e)
    {
        var hWnd = FindTargetWindow();
        if (hWnd == nint.Zero)
        {
            MessageBox.Show("Окно Task2_MainWindow не найдено. Сначала запустите его.", "Ошибка");
            return;
        }

        SendMessage(hWnd, WM_SYSCOMMAND, (nint)SC_MINIMIZE, nint.Zero);
    }
}
