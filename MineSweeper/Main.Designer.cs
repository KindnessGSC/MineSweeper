namespace MineSweeper
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Leaderboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettingButton = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuButton,
            this.toolStripSeparator1,
            this.toolStripSettingButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(329, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuButton
            // 
            this.MenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.Leaderboard,
            this.Exit});
            this.MenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuButton.Image")));
            this.MenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(29, 22);
            this.MenuButton.Text = "MenuButton";
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            // 
            // Leaderboard
            // 
            this.Leaderboard.Name = "Leaderboard";
            this.Leaderboard.Size = new System.Drawing.Size(192, 22);
            this.Leaderboard.Text = "Рейтинг победителей";
            this.Leaderboard.Click += new System.EventHandler(this.Leaderboard_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSettingButton
            // 
            this.toolStripSettingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettingButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettingButton.Image")));
            this.toolStripSettingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettingButton.Name = "toolStripSettingButton";
            this.toolStripSettingButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripSettingButton.Text = "Настройки";
            this.toolStripSettingButton.Click += new System.EventHandler(this.SettingOpenClick);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(192, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 400);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Сапёр";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton MenuButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripSettingButton;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Leaderboard;
        private System.Windows.Forms.ToolStripMenuItem Exit;
    }
}

