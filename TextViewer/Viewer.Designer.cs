using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using static InputDialog.InputDialog;

namespace Viewer;

partial class Viewer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        splitContainer1 = new SplitContainer();
        btnSearch = new Button();
        chkWordWrap = new CheckBox();
        rtbContent = new RichTextBox();
        tt = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Cursor = Cursors.HSplit;
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(btnSearch);
        splitContainer1.Panel1.Controls.Add(chkWordWrap);
        splitContainer1.Panel1.Cursor = Cursors.Default;
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(rtbContent);
        splitContainer1.Size = new Size(800, 450);
        splitContainer1.SplitterDistance = 25;
        splitContainer1.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Dock = DockStyle.Right;
        btnSearch.Location = new Point(725, 0);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(75, 25);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "&Search";
        tt.SetToolTip(btnSearch, "F3 or CTRL-F to find next");
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // chkWordWrap
        // 
        chkWordWrap.AutoSize = true;
        chkWordWrap.Dock = DockStyle.Left;
        chkWordWrap.Location = new Point(0, 0);
        chkWordWrap.Name = "chkWordWrap";
        chkWordWrap.Padding = new Padding(4, 0, 0, 0);
        chkWordWrap.Size = new Size(90, 25);
        chkWordWrap.TabIndex = 0;
        chkWordWrap.Text = "Word Wrap";
        chkWordWrap.UseVisualStyleBackColor = true;
        chkWordWrap.CheckedChanged += chkWordWrap_CheckedChanged;
        // 
        // rtbContent
        // 
        rtbContent.Cursor = Cursors.IBeam;
        rtbContent.Dock = DockStyle.Fill;
        rtbContent.Location = new Point(0, 0);
        rtbContent.Margin = new Padding(6);
        rtbContent.Name = "rtbContent";
        rtbContent.ReadOnly = true;
        rtbContent.Size = new Size(800, 421);
        rtbContent.TabIndex = 0;
        rtbContent.Text = "";
        rtbContent.SelectionChanged += rtbContent_SelectionChanged;
        // 
        // Viewer
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(splitContainer1);
        KeyPreview = true;
        Name = "Viewer";
        Text = "Log Viewer";
        FormClosing += Viewer_FormClosing;
        KeyUp += Viewer_KeyUp;
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.CheckBox chkWordWrap;
    private System.Windows.Forms.RichTextBox rtbContent;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.ToolTip tt;
}