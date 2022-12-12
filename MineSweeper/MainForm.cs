using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

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
