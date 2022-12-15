using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
	public partial class inputName : Form
	{
		public string name;
		public inputName()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(NameTextBox.Text == null)
			{
				MessageBox.Show("введите ник!");
			}
			else if (NameTextBox.Text == "")
			{
				MessageBox.Show("введите ник!");
			}
			else if (NameTextBox.Text.Length > 16)
			{
				MessageBox.Show("Слишком длинный ник! " +
					"(должен быть не более 16 символов)");
			}
			else{
				name = NameTextBox.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
