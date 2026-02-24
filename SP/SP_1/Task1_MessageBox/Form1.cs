using System.Runtime.InteropServices;

namespace Task1_MessageBox;

public partial class Form1 : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBoxW(nint hWnd, string text, string caption, uint type);

    public Form1()
    {
        InitializeComponent();
    }

    private void showInfoButton_Click(object sender, EventArgs e)
    {
        MessageBoxW(IntPtr.Zero, "Имя: Виктор", "Информация", 0);
        MessageBoxW(IntPtr.Zero, "Группа: BW411", "Информация", 0);
        MessageBoxW(IntPtr.Zero, "Ну и еще че нить", "Информация", 0);
    }
}
