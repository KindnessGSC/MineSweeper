﻿namespace MineSweeper
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettingButton = new System.Windows.Forms.ToolStripButton();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сбросТекущейИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингПобедителейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.сбросТекущейИгрыToolStripMenuItem,
            this.рейтингПобедителейToolStripMenuItem});
            this.MenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuButton.Image")));
            this.MenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(29, 22);
            this.MenuButton.Text = "MenuButton";
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
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            // 
            // сбросТекущейИгрыToolStripMenuItem
            // 
            this.сбросТекущейИгрыToolStripMenuItem.Name = "сбросТекущейИгрыToolStripMenuItem";
            this.сбросТекущейИгрыToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.сбросТекущейИгрыToolStripMenuItem.Text = "Сброс текущей игры";
            // 
            // рейтингПобедителейToolStripMenuItem
            // 
            this.рейтингПобедителейToolStripMenuItem.Name = "рейтингПобедителейToolStripMenuItem";
            this.рейтингПобедителейToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.рейтингПобедителейToolStripMenuItem.Text = "Рейтинг победителей";
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
        private System.Windows.Forms.ToolStripMenuItem сбросТекущейИгрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейтингПобедителейToolStripMenuItem;
    }
}

