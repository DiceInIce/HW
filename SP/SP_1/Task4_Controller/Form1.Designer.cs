namespace Task4_Controller;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Button applyDarkThemeButton;
    private Button applyLightThemeButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        applyDarkThemeButton = new Button();
        applyLightThemeButton = new Button();
        SuspendLayout();

        applyDarkThemeButton.Location = new Point(15, 15);
        applyDarkThemeButton.Name = "applyDarkThemeButton";
        applyDarkThemeButton.Size = new Size(220, 35);
        applyDarkThemeButton.TabIndex = 0;
        applyDarkThemeButton.Text = "Тёмная тема для окна Task4";
        applyDarkThemeButton.UseVisualStyleBackColor = true;
        applyDarkThemeButton.Click += applyDarkThemeButton_Click;

        applyLightThemeButton.Location = new Point(15, 60);
        applyLightThemeButton.Name = "applyLightThemeButton";
        applyLightThemeButton.Size = new Size(220, 35);
        applyLightThemeButton.TabIndex = 1;
        applyLightThemeButton.Text = "Светлая тема для окна Task4";
        applyLightThemeButton.UseVisualStyleBackColor = true;
        applyLightThemeButton.Click += applyLightThemeButton_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(260, 115);
        Controls.Add(applyLightThemeButton);
        Controls.Add(applyDarkThemeButton);
        Name = "Form1";
        Text = "Task4 Controller";
        ResumeLayout(false);
    }
}
