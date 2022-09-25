using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            FieldUserControl field = new FieldUserControl();
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            SettingForm form = new SettingForm();
            form.ShowDialog();
		}
    }
}
