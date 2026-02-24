namespace Task2_MainWindow;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label infoLabel;

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
        infoLabel = new Label();
        SuspendLayout();

        infoLabel.AutoSize = true;
        infoLabel.Location = new Point(20, 20);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new Size(248, 15);
        infoLabel.TabIndex = 0;
        infoLabel.Text = "Это главное окно для задания 2 (WinAPI).";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 120);
        Controls.Add(infoLabel);
        Name = "Form1";
        Text = "Task2 Main Window";
        ResumeLayout(false);
        PerformLayout();
    }

}
