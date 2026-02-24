namespace Task2_Controller;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label titleLabel;
    private TextBox titleTextBox;
    private Button changeTitleButton;
    private Button closeWindowButton;
    private Button minimizeWindowButton;

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
        titleLabel = new Label();
        titleTextBox = new TextBox();
        changeTitleButton = new Button();
        closeWindowButton = new Button();
        minimizeWindowButton = new Button();
        SuspendLayout();

        titleLabel.AutoSize = true;
        titleLabel.Location = new Point(15, 15);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(262, 15);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Новый заголовок окна Task2 Main Window:";

        titleTextBox.Location = new Point(15, 35);
        titleTextBox.Name = "titleTextBox";
        titleTextBox.Size = new Size(360, 23);
        titleTextBox.TabIndex = 1;

        changeTitleButton.Location = new Point(15, 70);
        changeTitleButton.Name = "changeTitleButton";
        changeTitleButton.Size = new Size(170, 30);
        changeTitleButton.TabIndex = 2;
        changeTitleButton.Text = "Изменить заголовок";
        changeTitleButton.UseVisualStyleBackColor = true;
        changeTitleButton.Click += changeTitleButton_Click;

        closeWindowButton.Location = new Point(205, 70);
        closeWindowButton.Name = "closeWindowButton";
        closeWindowButton.Size = new Size(170, 30);
        closeWindowButton.TabIndex = 3;
        closeWindowButton.Text = "Закрыть окно";
        closeWindowButton.UseVisualStyleBackColor = true;
        closeWindowButton.Click += closeWindowButton_Click;

        minimizeWindowButton.Location = new Point(15, 110);
        minimizeWindowButton.Name = "minimizeWindowButton";
        minimizeWindowButton.Size = new Size(360, 30);
        minimizeWindowButton.TabIndex = 4;
        minimizeWindowButton.Text = "Свернуть окно";
        minimizeWindowButton.UseVisualStyleBackColor = true;
        minimizeWindowButton.Click += minimizeWindowButton_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 160);
        Controls.Add(minimizeWindowButton);
        Controls.Add(closeWindowButton);
        Controls.Add(changeTitleButton);
        Controls.Add(titleTextBox);
        Controls.Add(titleLabel);
        Name = "Form1";
        Text = "Task2 Controller";
        ResumeLayout(false);
        PerformLayout();
    }

}
