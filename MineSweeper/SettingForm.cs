using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
	public partial class SettingForm : Form
	{
		public bool MusicPlay;
		public int difficult;

		public SettingForm()
		{
			InitializeComponent();
			
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			MuzicButtonChange();
			DifficultComboBox.SelectedIndex = difficult - 1;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void OkClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			difficult = DifficultComboBox.SelectedIndex + 1;
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

		private void SaveButton_Click(object sender, EventArgs e)
		{
			string fileName = null;
			SaveFileDialog saveFile = new SaveFileDialog
			{
				Filter = "Текстовые файлы *.txt|*.txt|Все файлы|*.*",
				FilterIndex = 1
			};
			if (saveFile.ShowDialog() == DialogResult.OK)
				fileName = saveFile.FileName;
			StreamWriter writer = null;
			bool save_file = false;
			if (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName))
				return;
			try
			{
				writer = new StreamWriter(fileName, false, Encoding.Default);
				if(MusicPlay)
					writer.WriteLine($"{DifficultComboBox.SelectedIndex + 1};{1}");
				else
					writer.WriteLine($"{DifficultComboBox.SelectedIndex + 1};{0}");

				writer.Close();
				save_file = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Ошибка при сохранение файла!", "Ошибка");
			}
			finally
			{
				if (writer != null)
					writer.Dispose();
			}
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{

		}
	}
}
