namespace TestApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnClickMe_Click(object sender, EventArgs e)
    {
        var viewer = new TextViewer.Viewer("Viewer1");
        viewer.LoadText("This is some text");
        viewer.Show();
    }

    private void btnViewFile_Click(object sender, EventArgs e)
    {
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            var viewer = new TextViewer.Viewer("Viewer2", "cmptname");
            viewer.LoadFile(ofd.FileName);
            viewer.Show();
        }
    }
}
