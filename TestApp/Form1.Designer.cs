namespace TestApp
{
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
            btnClickMe = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnClickMe
            // 
            btnClickMe.Location = new Point(0, 0);
            btnClickMe.Name = "btnClickMe";
            btnClickMe.Size = new Size(138, 23);
            btnClickMe.TabIndex = 0;
            btnClickMe.Text = "View Static Text";
            btnClickMe.UseVisualStyleBackColor = true;
            btnClickMe.Click += btnClickMe_Click;
            // 
            // button1
            // 
            button1.Location = new Point(0, 29);
            button1.Name = "button1";
            button1.Size = new Size(138, 23);
            button1.TabIndex = 1;
            button1.Text = "View FIle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnClickMe);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClickMe;
        private Button button1;
    }
}
