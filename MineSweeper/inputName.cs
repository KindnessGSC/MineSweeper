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

		static List<Player> _players;

		public static List<Player> Players 
		{ 
			get 
			{ 
				if( _players == null ) _players = new List<Player>();
				return _players;
			} 
			set { _players = value; }
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(_players == null) _players = new List<Player>();

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
			else
			{
				DialogResult = DialogResult.OK;
				Leaderboard.SaveData("save.dat", _players.ToArray());
				Close();
			}
		}
	}
}
