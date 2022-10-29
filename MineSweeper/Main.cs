using System;
using System.Windows.Forms;
using System.Drawing;
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
            field.Initialize(9, 25);

            int posX = (int)((this.Width - field.Width) * 0.5);
            int posY = (int)((this.Height - field.Height) * 0.5);

            //int errorPosX = (int)();

            field.Location = new Point(posX, posY);
            Controls.Add(field);
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
            //player.Play();
		}
	}
}
