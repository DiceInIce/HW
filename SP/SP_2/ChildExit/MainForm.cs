using System;
using System.Windows.Forms;

namespace ChildExit;

public class MainForm : Form
{
    private readonly Button _exitButton;

    public MainForm()
    {
        Text = "Дочерний процесс";
        StartPosition = FormStartPosition.CenterScreen;
        Width = 300;
        Height = 150;

        _exitButton = new Button
        {
            Text = "Выход",
            Width = 100,
            Height = 30
        };

        _exitButton.Click += (_, _) => Close();

        Controls.Add(_exitButton);
        Layout += OnLayout;
    }

    private void OnLayout(object? sender, EventArgs e)
    {
        _exitButton.Left = (ClientSize.Width - _exitButton.Width) / 2;
        _exitButton.Top = (ClientSize.Height - _exitButton.Height) / 2;
    }
}

