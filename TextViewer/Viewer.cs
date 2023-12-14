using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using static InputDialog.InputDialog;

namespace Viewer;


public partial class Viewer : Form
{
    private readonly string _Title;
    private string srchTxt = string.Empty;
    private List<string> _searchTexts = new();
    private string _searchFileSource = string.Empty;
    private readonly string _srchName;

    public Viewer(string srchName = "TxtVwrSrchHst")
    {
        ArgumentNullException.ThrowIfNull(nameof(srchName));
        InitializeComponent();
        _srchName = srchName;
        _Title = srchName;
        LoadPriorSearches();
    }

    public void LoadText(string text)
    {
        rtbContent.WordWrap = chkWordWrap.Checked = true;
        rtbContent.Lines = new string[] { text };
        ApplyPadding(5);
    }

    public void LoadText(string[] lines)
    {
        rtbContent.WordWrap = chkWordWrap.Checked = true;
        rtbContent.Lines = lines;
        ApplyPadding(5);
    }

    public void LoadFile(string filepath)
    {
        rtbContent.Lines = System.Array.Empty<string>();
        rtbContent.WordWrap = chkWordWrap.Checked = true;
        if (File.Exists(filepath))
        {
            try
            {
                if (Path.GetExtension(filepath).Contains(".rtf"))
                    rtbContent.LoadFile(filepath);
                else
                    rtbContent.LoadFile(filepath, RichTextBoxStreamType.PlainText);
                ApplyPadding(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load {filepath}.{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            var msg = $"Could not load {filepath}";
            rtbContent.Lines = new string[] { msg };
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadPriorSearches()
    {
        var appname = Process.GetCurrentProcess().ProcessName;
        var programDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        _searchFileSource = @$"{programDataFolder}\HotRS\TextViewer\{appname}\ViewerSearches-{_srchName}.txt";
        if (File.Exists(_searchFileSource))
        {
            var priorSearches = File.ReadAllLines(_searchFileSource);
            _searchTexts = new List<string>(priorSearches);
        }
    }

    public void ApplyPadding(int width)
    {
        rtbContent.SelectAll();
        rtbContent.SelectionIndent += width;
        rtbContent.SelectionRightIndent += width;
        rtbContent.SelectionLength = 0;
        //this is a little hack because without it the first line of the RTB is selected anyway.
        rtbContent.SelectionBackColor = rtbContent.BackColor;
    }

    private void btnSearch_Click(object sender, System.EventArgs e)
    {
        var dr = InputDialog.InputDialog.ShowDialog(
            message: "Enter Search Text",
            title: "Search",
            icon: IDIcon.Question,
            button: IDButton.OkCancel,
            type: IDType.ComboBox,
            listItems: _searchTexts.Any() ? _searchTexts : new List<string> { string.Empty },
            buttonTexts: new InputDialog.ButtonTexts { OKText = "Search" });
        if (dr.DialogResult == DialogResult.OK)
        {
            srchTxt = dr.ResultText;
            UpdateSearchList(srchTxt);
            rtbContent.SearchRTF(srchTxt);
        }
    }
    private void UpdateSearchList(string searchText)
    {
        if (_searchTexts.Contains(searchText))
        {
            _searchTexts.Remove(searchText);
        }
        _searchTexts.Insert(0, searchText);
    }

    private void SaveSearchesToDisk()
    {
        if (_searchTexts.Count > 100)
        {
            _searchTexts.RemoveRange(100, _searchTexts.Count - 100);
        }
        if (_searchTexts.Count > 0)
        {
            EnsureFolder(_searchFileSource);
            File.WriteAllLines(_searchFileSource, _searchTexts);
        }
    }

    private static void EnsureFolder(string filename)
    { 
        ArgumentNullException.ThrowIfNull(nameof(filename));
        var path = Path.GetDirectoryName(filename);
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Could not generate file to store searches. Filename was null or empty.");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
    private void chkWordWrap_CheckedChanged(object sender, System.EventArgs e)
    {
        rtbContent.WordWrap = chkWordWrap.Checked;
    }

    private void rtbContent_SelectionChanged(object sender, System.EventArgs e)
    {
        if (sender is RichTextBox sndr)
        {
            var position = GetTextBoxPosition(sndr);
            Text = $"{_Title} ({position.X}, {position.Y})";
        }
        else
        {
            throw new ApplicationException("Internal Error: Email the developer." );
        }    
    }
    private void Viewer_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveSearchesToDisk();
    }
    private void Viewer_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            SaveSearchesToDisk();
            this.Close();
        }
        if (!string.IsNullOrWhiteSpace(srchTxt)
            && (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F)))
            rtbContent.SearchRTF(srchTxt);
    }

    private static Point GetTextBoxPosition(RichTextBox rtb)
    {
        Point pt;
        int line, col, index;
        // get the current line
        index = rtb.SelectionStart;
        line = rtb.GetLineFromCharIndex(index);
        // get the caret position in pixel coordinates
        pt = rtb.GetPositionFromCharIndex(index);
        // now get the character index at the start of the line, and
        // subtract from the current index to get the column
        pt.X = 0;
        col = index - rtb.GetCharIndexFromPosition(pt);
        return new Point(line, col);
    }

}
