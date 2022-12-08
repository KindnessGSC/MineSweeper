﻿using System;
using System.Windows.Forms;

namespace MineSweeper
{
	public partial class SettingForm : Form
	{
		public bool MusicPlay;

		public SettingForm()
		{
			InitializeComponent();
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			MuzicButtonChange();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void OkClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void MuzicButton_Click(object sender, EventArgs e)
		{
			MusicPlay = !MusicPlay;
			MuzicButtonChange();
		}

		private void MuzicButtonChange()
		{
			if (MusicPlay)
				MuzicButton.Text = "Вкл";
			else
				MuzicButton.Text = "Выкл";
		}
	}
}
