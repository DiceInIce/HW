namespace Task3_Beep;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label patternLabel;
    private Button startBeepButton;

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
        patternLabel = new Label();
        startBeepButton = new Button();
        SuspendLayout();

        patternLabel.AutoSize = true;
        patternLabel.Location = new Point(15, 15);
        patternLabel.Name = "patternLabel";
        patternLabel.Size = new Size(292, 15);
        patternLabel.TabIndex = 0;
        patternLabel.Text = "Нажмите кнопку, чтобы воспроизвести звукоряд.";

        startBeepButton.Location = new Point(15, 40);
        startBeepButton.Name = "startBeepButton";
        startBeepButton.Size = new Size(200, 35);
        startBeepButton.TabIndex = 1;
        startBeepButton.Text = "Воспроизвести сигналы";
        startBeepButton.UseVisualStyleBackColor = true;
        startBeepButton.Click += startBeepButton_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(360, 100);
        Controls.Add(startBeepButton);
        Controls.Add(patternLabel);
        Name = "Form1";
        Text = "Задание 3 - Beep";
        ResumeLayout(false);
        PerformLayout();
    }

}
