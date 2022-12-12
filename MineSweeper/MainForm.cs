﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        SoundPlayer muzicPlayer = null;
        bool muzicPlay = true;

        private FieldUserControl _field;
        private Label _label;

        private const int heightOffset = 20;
        private const int widthOffset = 18;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            _field = new FieldUserControl(1, 35);
            _field.GenerateField();

            _label = new Label();
            _label.AutoSize = true;

            _label.Location = new Point(_label.Location.X, _label.Location.Y + toolStrip1.Height);

            _field.Location = new Point(_field.Location.X, _field.Location.Y + toolStrip1.Height + heightOffset);
            Controls.Add(_field);
            Controls.Add(_label);
            Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            //открытие и сохранение настроек
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

                _field.ChangeDiffucltly(form.difficult);
                Size = new Size(_field.FieldSize + widthOffset, _field.FieldSize + (toolStrip1.Height * 2) + heightOffset * 2);
            }
		}

        private void Main_Load(object sender, EventArgs e)
		{
            timer1.Start();
            string musicPath = "Music12.wav";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1);
            _label.Text = $"Количество флажков: {_field.BombsCount}";
        }
    }
}
