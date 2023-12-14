namespace TestApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        btnClickMe = new Button();
        btnViewFile = new Button();
        ofd = new OpenFileDialog();
        tt = new ToolTip(components);
        SuspendLayout();
        // 
        // btnClickMe
        // 
        btnClickMe.Location = new Point(44, 12);
        btnClickMe.Name = "btnClickMe";
        btnClickMe.Size = new Size(138, 23);
        btnClickMe.TabIndex = 0;
        btnClickMe.Text = "View Static Text";
        tt.SetToolTip(btnClickMe, "Pass predetermined text to viewer");
        btnClickMe.UseVisualStyleBackColor = true;
        btnClickMe.Click += btnClickMe_Click;
        // 
        // btnViewFile
        // 
        btnViewFile.Location = new Point(44, 41);
        btnViewFile.Name = "btnViewFile";
        btnViewFile.Size = new Size(138, 23);
        btnViewFile.TabIndex = 1;
        btnViewFile.Text = "View FIle";
        tt.SetToolTip(btnViewFile, "Open file dialog to select a file");
        btnViewFile.UseVisualStyleBackColor = true;
        btnViewFile.Click += btnViewFile_Click;
        // 
        // ofd
        // 
        ofd.DefaultExt = "txt";
        ofd.Filter = "Text Files|*.txt|Rich Text Files|*.rtf|All FIles|*.*";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(215, 74);
        Controls.Add(btnViewFile);
        Controls.Add(btnClickMe);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        SizeGripStyle = SizeGripStyle.Hide;
        Text = "Viewer";
        ResumeLayout(false);
    }

    #endregion

    private Button btnClickMe;
    private Button btnViewFile;
    private OpenFileDialog ofd;
    private ToolTip tt;
}
