namespace Task4_MainWindow;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private TextBox inputTextBox;
    private Button actionButton;
    private CheckBox demoCheckBox;
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
        inputTextBox = new TextBox();
        actionButton = new Button();
        demoCheckBox = new CheckBox();
        infoLabel = new Label();
        SuspendLayout();

        inputTextBox.Location = new Point(20, 40);
        inputTextBox.Name = "inputTextBox";
        inputTextBox.Size = new Size(260, 23);
        inputTextBox.TabIndex = 0;
        inputTextBox.Text = "Пример текста";

        actionButton.Location = new Point(20, 75);
        actionButton.Name = "actionButton";
        actionButton.Size = new Size(120, 30);
        actionButton.TabIndex = 1;
        actionButton.Text = "Кнопка";
        actionButton.UseVisualStyleBackColor = true;

        demoCheckBox.AutoSize = true;
        demoCheckBox.Location = new Point(20, 115);
        demoCheckBox.Name = "demoCheckBox";
        demoCheckBox.Size = new Size(140, 19);
        demoCheckBox.TabIndex = 2;
        demoCheckBox.Text = "Демонстрационный чекбокс";
        demoCheckBox.UseVisualStyleBackColor = true;
 
        infoLabel.AutoSize = true;
        infoLabel.Location = new Point(20, 15);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new Size(279, 15);
        infoLabel.TabIndex = 3;
        infoLabel.Text = "Окно для задания 4 (элементы будут стилизованы).";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 160);
        Controls.Add(infoLabel);
        Controls.Add(demoCheckBox);
        Controls.Add(actionButton);
        Controls.Add(inputTextBox);
        Name = "Form1";
        Text = "Task4 Main Window";
        ResumeLayout(false);
        PerformLayout();
    }

}
