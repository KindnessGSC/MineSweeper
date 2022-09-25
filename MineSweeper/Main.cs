using System;
using System.Windows.Forms;
using System.Media;

namespace MineSweeper
{
    public partial class Main : Form
    {
        SoundPlayer player = null;
        public Main()
        {
            InitializeComponent();
            FieldUserControl field = new FieldUserControl();
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            SettingForm form = new SettingForm();
            form.ShowDialog();
		}

		private void Main_Load(object sender, EventArgs e)
		{
            player = new SoundPlayer();
            player.SoundLocation = "Music1.wav";
            player.Play();
		}
	}
}
