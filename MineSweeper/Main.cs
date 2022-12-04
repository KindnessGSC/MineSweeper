using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;

namespace MineSweeper
{
    public partial class Main : Form
    {
        SoundPlayer muzicPlayer = null;
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
                        muzicPlayer.PlayLooping();
                    }
                    else
                    {
                        muzicPlayer.Stop();
                    }
                }
			}
		}

        private void Main_Load(object sender, EventArgs e)
		{
            muzicPlayer = new SoundPlayer();
            //muzicPlayer.SoundLocation = "Music1.wav";
            //muzicPlayer.PlayLooping();
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

        private void Leaderboard_Click(object sender, EventArgs e)
        {
            //открытие таблицы лидеров
            CSFormLeaderboards form = new CSFormLeaderboards();
            form.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
