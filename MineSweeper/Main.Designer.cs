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
			this.SettingButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SettingButton
			// 
			this.SettingButton.Location = new System.Drawing.Point(120, 56);
			this.SettingButton.Margin = new System.Windows.Forms.Padding(2);
			this.SettingButton.Name = "SettingButton";
			this.SettingButton.Size = new System.Drawing.Size(469, 31);
			this.SettingButton.TabIndex = 0;
			this.SettingButton.Text = "Настройки";
			this.SettingButton.UseVisualStyleBackColor = true;
			this.SettingButton.Click += new System.EventHandler(this.SettingOpenClikc);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 366);
			this.Controls.Add(this.SettingButton);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Main";
			this.Text = "Сапёр";
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button SettingButton;
	}
}

