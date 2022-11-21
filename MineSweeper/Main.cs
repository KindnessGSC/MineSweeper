using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;

namespace MineSweeper
{
    public partial class Main : Form
    {
        SoundPlayer player = null;
        bool muzicPlay = true;
        public Main()
        {
            InitializeComponent();

            FieldUserControl field = new FieldUserControl();
            field.Initialize(8, 50);
            ConfigureFieldLocation(field);
            InputSystem.map = field;
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            //открытие и сохранение настроек
            SettingForm form = new SettingForm();
            form.MuzicPlay = muzicPlay;
            form.ShowDialog();
            //сохранение параметров 
            if(form.DialogResult == DialogResult.OK)
			{
                //музыка
                if (muzicPlay != form.MuzicPlay)
                {
                    muzicPlay = form.MuzicPlay;
                    if (muzicPlay)
                    {
                        player.PlayLooping();
                    }
                    else
                    {
                        player.Stop();
                    }
                }
			}
		}

        private void Main_Load(object sender, EventArgs e)
		{
            player = new SoundPlayer();
            //player.SoundLocation = "Music1.wav";
            //player.PlayLooping();
		}

        private void ConfigureFieldLocation(FieldUserControl field)
        {
            field.Anchor = AnchorStyles.None;

            int posX = (int)((this.Width - field.Width) * 0.5) - 1;
            int posY = (int)((this.Height - field.Height) * 0.5) + 1;

            int errorPosX = (int)(posX * 0.25) + 1;
            posX -= errorPosX;

            field.Location = new Point(posX, posY);
            Controls.Add(field);
        }

		private void Main_MouseClick(object sender, MouseEventArgs e)
		{
            InputSystem.CellInput(e);
		}

		private void MenuButton_Click(object sender, EventArgs e)
		{

		}
	}
}
