using System.Runtime.InteropServices;

namespace Task3_Beep;

public partial class Form1 : Form
{
    [DllImport("kernel32.dll")]
    private static extern bool Beep(uint dwFreq, uint dwDuration);

    [DllImport("user32.dll")]
    private static extern bool MessageBeep(uint uType);

    public Form1()
    {
        InitializeComponent();
    }

    private async void startBeepButton_Click(object sender, EventArgs e)
    {
        startBeepButton.Enabled = false;

        Beep(440, 300); // A4
        await Task.Delay(200);
        Beep(660, 300); // E5
        await Task.Delay(200);
        Beep(880, 300); // A5
        await Task.Delay(400);

        MessageBeep(0x00000010); // MB_ICONHAND
        await Task.Delay(300);
        MessageBeep(0x00000040); // MB_ICONINFORMATION
        await Task.Delay(300);
        MessageBeep(0x00000030); // MB_ICONWARNING

        startBeepButton.Enabled = true;
    }
}
