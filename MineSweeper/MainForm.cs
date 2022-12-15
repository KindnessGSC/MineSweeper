using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Linq;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        //игрок
        Player player = new Player();

        SoundPlayer muzicPlayer = null;
        bool muzicPlay = true;

        private FieldUserControl _field;
        private readonly Label _flagsCountLabel;
        private readonly Label _timerLabel;

        private const int heightOffset = 20;
        private const int widthOffset = 18;

        public MainForm()
        {
            InitializeComponent();

            this.FormClosed += MainForm_FormClosed;

            StartPosition = FormStartPosition.CenterScreen;

            _field = new FieldUserControl(1, 35);
            _field.NewGame();

            _flagsCountLabel = new Label();
            _timerLabel = new Label();
            _flagsCountLabel.AutoSize = true;
            _timerLabel.AutoSize = true;
            _timerLabel.Text = "0 секунд";
            _flagsCountLabel.Text = $"Количество флажков: {_field.FlagsCount}";

            _flagsCountLabel.Location = new Point(_flagsCountLabel.Location.X, _flagsCountLabel.Location.Y + toolStrip1.Height);
            _timerLabel.Location = new Point(Width - (Width / 2) + 5, _timerLabel.Location.Y + toolStrip1.Height);

            _field.Location = new Point(_field.Location.X, _field.Location.Y + toolStrip1.Height + heightOffset);
            Controls.Add(_field);
            Controls.Add(_flagsCountLabel);
            Controls.Add(_timerLabel);
            Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
            _field.Win += OnWin;
            _field.Lose += OnLose;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(inputName.Players.Count > 0)
            {
                MineSweeper.Leaderboard.SaveData("save.dat", inputName.Players.ToArray());
            }
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
                    i = 0;
                    _field.ChangeDiffucltly(form.difficult);
                    Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
                    if(form.difficult == 1) _timerLabel.Location = new Point(Width - (Width / 2) + 5, _timerLabel.Location.Y + toolStrip1.Height);
                    else if(form.difficult == 2) _timerLabel.Location = new Point(Width - (Width / 5), _timerLabel.Location.Y);
                    else if(form.difficult == 3) _timerLabel.Location = new Point(Width - (Width / 6) + 20, _timerLabel.Location.Y);
                    timer1.Start();
                }
            }
		}

        private void Main_Load(object sender, EventArgs e)
		{
            timer1.Start();
            string musicPath = "Music1.wav";
            muzicPlayer = new SoundPlayer();
            inputName.Players = MineSweeper.Leaderboard.LoadData("save.dat").ToList();

            try
            {
                muzicPlayer.SoundLocation = musicPath;
                if (muzicPlay)
                {
                    muzicPlayer.PlayLooping();
                }
            }
            catch
            {
                
            }
        }

        private void Leaderboard_Click(object sender, EventArgs e)
        {
            //открытие таблицы лидеров
            Leaderboard form = new Leaderboard();
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

        int i;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1);
            _flagsCountLabel.Text = $"Количество флажков: {_field.FlagsCount}";
            _timerLabel.Text = $"{Math.Round(i * 0.1)} секунд";
            if (_field.IsStarted)
            {
                i++;
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            timer1.Start();
            _field.NewGame();
        }
        //обработчик победы
        public void OnWin()
		{
            timer1.Stop();
            i = 0;

            string timeValue = new string(_timerLabel.Text.Where(x => char.IsDigit(x)).ToArray());
            inputName.Players = inputName.Players.Distinct().ToList();

            inputName form = new inputName();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

            inputName.Players.Add(new Player() 
            {
                Name = form.NameTextBox.Text,
                Difficult = _field.FieldDifficultly,
                Time = int.Parse(timeValue)
            });
		}
        public void OnLose()
        {
            i = 0;
        }
    }
}
