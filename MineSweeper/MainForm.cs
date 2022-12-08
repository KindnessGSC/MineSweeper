using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        SoundPlayer muzicPlayer = null;
        bool muzicPlay = true;
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            FieldUserControl field = new FieldUserControl(1, 35);
            field.GenerateField();
            ConfigureFieldLocation(field);
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            //открытие и сохранение настроек
            SettingForm form = new SettingForm();
            form.MusicPlay = muzicPlay;
            form.ShowDialog();
            //сохранение параметров 
            if(form.DialogResult == DialogResult.OK)
			{
                //музыка
                if (muzicPlay != form.MusicPlay)
                {
                    muzicPlay = form.MusicPlay;
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
            string musicPath = "Music1.wav";
            muzicPlayer = new SoundPlayer();
            
            try
            {
                muzicPlayer.SoundLocation = musicPath;
                muzicPlayer.PlayLooping();
            }
            catch (Exception)
            {
                
            }
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
