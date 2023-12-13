namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            var viewer = new Viewer.Viewer("Viewer1");
            viewer.LoadText("This is some text");
            viewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var viewer = new Viewer.Viewer("Viewer2");
            viewer.LoadFile(@"D:\Projects\TextViewer\TestApp\TestFiles\ImageCataloger-20231204.log");
            viewer.Show();
        }
    }
}
