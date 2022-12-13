using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        //имя игрока
        public string PlayerName;

        SoundPlayer muzicPlayer = null;
        bool muzicPlay = true;

        private FieldUserControl _field;
        private readonly Label _label;

        private const int heightOffset = 20;
        private const int widthOffset = 18;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            _field = new FieldUserControl(1, 35);
            _field.NewGame();

            _label = new Label();
            _label.AutoSize = true;

            _label.Location = new Point(_label.Location.X, _label.Location.Y + toolStrip1.Height);

            _field.Location = new Point(_field.Location.X, _field.Location.Y + toolStrip1.Height + heightOffset);
            Controls.Add(_field);
            Controls.Add(_label);
            Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
            _field.Win += OnWin();
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            //открытие настроек
            SettingForm form = new SettingForm();
            form.MusicPlay = muzicPlay;
            form.difficult = _field.FieldDifficultly;
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
                //cложность
                if (_field.FieldDifficultly != form.difficult)
                {
                    _field.ChangeDiffucltly(form.difficult);
                    Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
                }
            }
		}

        private void Main_Load(object sender, EventArgs e)
		{
            timer1.Start();
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
            DialogResult result = MessageBox.Show(
           "Вы хотите выйти из приложения?",
           "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                Close();
            
            this.TopMost = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1);
            _label.Text = $"Количество флажков: {_field.FlagsCount}";
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            _field.NewGame();
        }
        //обработчик победы
        public FieldUserControl.WinHandler OnWin()
		{
            inputName form = new inputName();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
			{
                PlayerName = form.NameTextBox.Text;
			}

            return null;
		}
    }
}
