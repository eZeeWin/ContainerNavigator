using System;
using System.Windows.Forms;

namespace ContainerNavigator.GUI.Panels
{
    public partial class Settings : Panel
    {
        public string ImageLocation {
            get => Location.Text;
            set => Location.Text = value;
        }
        public bool Show => ShowGUI.Checked;

        private readonly OpenFileDialog ofd = new OpenFileDialog { Title = "Select Container Image" }; 

        public Settings() => InitializeComponent();

        private void Location_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            ImageLocation = ofd.FileName;
        }
    }
}
