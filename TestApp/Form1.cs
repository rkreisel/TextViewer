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
    }
}