using System.Runtime.InteropServices;

namespace Task4_Controller;

public partial class Form1 : Form
{
    private const int WM_APP = 0x8000;
    private const int MSG_THEME_DARK = WM_APP + 1;
    private const int MSG_THEME_LIGHT = WM_APP + 2;

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern nint FindWindow(string? lpClassName, string? lpWindowName);

    [DllImport("user32.dll")]
    private static extern nint SendMessage(nint hWnd, uint msg, nint wParam, nint lParam);

    public Form1()
    {
        InitializeComponent();
    }

    private nint FindTask4Window()
    {
        return FindWindow(null, "Task4 Main Window");
    }

    private void applyDarkThemeButton_Click(object sender, EventArgs e)
    {
        var hWnd = FindTask4Window();
        if (hWnd == nint.Zero)
        {
            MessageBox.Show("Окно Task4_MainWindow не найдено. Сначала запустите его.", "Ошибка");
            return;
        }

        SendMessage(hWnd, MSG_THEME_DARK, nint.Zero, nint.Zero);
    }

    private void applyLightThemeButton_Click(object sender, EventArgs e)
    {
        var hWnd = FindTask4Window();
        if (hWnd == nint.Zero)
        {
            MessageBox.Show("Окно Task4_MainWindow не найдено. Сначала запустите его.", "Ошибка");
            return;
        }

        SendMessage(hWnd, MSG_THEME_LIGHT, nint.Zero, nint.Zero);
    }
}
