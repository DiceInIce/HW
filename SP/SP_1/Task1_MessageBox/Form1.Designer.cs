namespace Task1_MessageBox;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Button showInfoButton;

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
        showInfoButton = new Button();
        SuspendLayout();

        showInfoButton.Location = new Point(30, 30);
        showInfoButton.Name = "showInfoButton";
        showInfoButton.Size = new Size(200, 40);
        showInfoButton.TabIndex = 0;
        showInfoButton.Text = "Показать информацию";
        showInfoButton.UseVisualStyleBackColor = true;
        showInfoButton.Click += showInfoButton_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 150);
        Controls.Add(showInfoButton);
        Name = "Form1";
        Text = "Задание 1 - MessageBox";
        ResumeLayout(false);
    }
}
