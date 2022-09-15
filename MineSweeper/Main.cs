using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

		private void SettingOpenClick(object sender, EventArgs e)
		{
            SettingForm form = new SettingForm();
            form.ShowDialog();
		}
	}
}
