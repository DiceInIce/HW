using System.Drawing;

namespace Task4_MainWindow;

public partial class Form1 : Form
{
    private const int WM_APP = 0x8000;
    private const int MSG_THEME_DARK = WM_APP + 1;
    private const int MSG_THEME_LIGHT = WM_APP + 2;

    public Form1()
    {
        InitializeComponent();
    }

    private void ApplyDarkTheme()
    {
        BackColor = Color.FromArgb(30, 30, 30);
        ForeColor = Color.White;

        infoLabel.ForeColor = Color.White;
        inputTextBox.BackColor = Color.FromArgb(45, 45, 45);
        inputTextBox.ForeColor = Color.White;

        actionButton.BackColor = Color.FromArgb(60, 60, 60);
        actionButton.ForeColor = Color.White;

        demoCheckBox.ForeColor = Color.White;
    }

    private void ApplyLightTheme()
    {
        BackColor = SystemColors.Control;
        ForeColor = SystemColors.ControlText;

        infoLabel.ForeColor = SystemColors.ControlText;
        inputTextBox.BackColor = Color.White;
        inputTextBox.ForeColor = SystemColors.WindowText;

        actionButton.BackColor = SystemColors.Control;
        actionButton.ForeColor = SystemColors.ControlText;

        demoCheckBox.ForeColor = SystemColors.ControlText;
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == MSG_THEME_DARK)
        {
            ApplyDarkTheme();
            return;
        }

        if (m.Msg == MSG_THEME_LIGHT)
        {
            ApplyLightTheme();
            return;
        }

        base.WndProc(ref m);
    }
}
