namespace MineSweeper
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Leaderboard = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesoftheGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSettingButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuButton,
            this.toolStripSeparator1,
            this.toolStripSettingButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(439, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MenuButton
            // 
            this.MenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.Leaderboard,
            this.Exit,
            this.RulesoftheGame});
            this.MenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuButton.Image")));
            this.MenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(34, 24);
            this.MenuButton.Text = "MenuButton";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Image = global::MineSweeper.Properties.Resources.new_game;
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Leaderboard
            // 
            this.Leaderboard.Image = global::MineSweeper.Properties.Resources.leaderboard;
            this.Leaderboard.Name = "Leaderboard";
            this.Leaderboard.Size = new System.Drawing.Size(249, 26);
            this.Leaderboard.Text = "Рейтинг победителей";
            this.Leaderboard.Click += new System.EventHandler(this.Leaderboard_Click);
            // 
            // Exit
            // 
            this.Exit.Image = global::MineSweeper.Properties.Resources.exit;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(249, 26);
            this.Exit.Text = "Выход из приложения";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // RulesoftheGame
            // 
            this.RulesoftheGame.Image = global::MineSweeper.Properties.Resources.rules;
            this.RulesoftheGame.Name = "RulesoftheGame";
            this.RulesoftheGame.Size = new System.Drawing.Size(249, 26);
            this.RulesoftheGame.Text = "Правила игры";
            this.RulesoftheGame.Click += new System.EventHandler(this.RulesoftheGame_Click);
            // 
            // toolStripSettingButton
            // 
            this.toolStripSettingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettingButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettingButton.Image")));
            this.toolStripSettingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettingButton.Name = "toolStripSettingButton";
            this.toolStripSettingButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripSettingButton.Text = "Настройки";
            this.toolStripSettingButton.Click += new System.EventHandler(this.SettingOpenClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 492);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Сапёр";
            this.Load += new System.EventHandler(this.Main_Load);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem RulesoftheGame;
    }
}

