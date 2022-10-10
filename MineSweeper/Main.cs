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
            field.GenerateField(9, 25, ClientRectangle);
            field.Click += FieldClick;
            Controls.Add(field);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        private void FieldClick(object sender, EventArgs e)
        {
            MessageBox.Show("Field is pressed!");
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
