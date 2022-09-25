using System;
using System.Windows.Forms;

namespace MineSweeper
{
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			InitializeComponent();
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{

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
	}
}
