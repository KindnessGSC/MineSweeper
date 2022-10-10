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
            field.GenerateField(9, 25, ClientRectangle);
            field.Click += FieldClick;
            Controls.Add(field);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        private void FieldClick(object sender, EventArgs e)
        {
            MessageBox.Show("Field is pressed!");
        }

        private void SettingOpenClick(object sender, EventArgs e)
		{
            SettingForm form = new SettingForm();
            form.ShowDialog();
		}
    }
}
