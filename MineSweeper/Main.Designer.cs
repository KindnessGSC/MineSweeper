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
<<<<<<< HEAD
			this.SettingButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SettingButton
			// 
			this.SettingButton.Location = new System.Drawing.Point(27, 34);
			this.SettingButton.Margin = new System.Windows.Forms.Padding(2);
			this.SettingButton.Name = "SettingButton";
			this.SettingButton.Size = new System.Drawing.Size(84, 31);
			this.SettingButton.TabIndex = 0;
			this.SettingButton.Text = "Настройки";
			this.SettingButton.UseVisualStyleBackColor = true;
			this.SettingButton.Click += new System.EventHandler(this.SettingOpenClikc);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 297);
			this.Controls.Add(this.SettingButton);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Main";
			this.Text = "Сапёр";
			this.ResumeLayout(false);
=======
            this.SettingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingButton
            // 
            this.SettingButton.Location = new System.Drawing.Point(160, 69);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(625, 38);
            this.SettingButton.TabIndex = 0;
            this.SettingButton.Text = "Настройки";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingOpenClikc);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SettingButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "Сапёр";
            this.ResumeLayout(false);
>>>>>>> 2dd4549762bbdd21e8e250d2561c555c525b71c5

        }

		#endregion

		private System.Windows.Forms.Button SettingButton;
	}
}

