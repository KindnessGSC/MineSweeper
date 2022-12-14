
namespace MineSweeper
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewGame = new System.Windows.Forms.Button();
            this.Leaderboard = new System.Windows.Forms.Button();
            this.RulesoftheGame = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(75, 28);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(125, 33);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "Новая игра";
            this.NewGame.UseVisualStyleBackColor = true;
            // 
            // Leaderboard
            // 
            this.Leaderboard.Location = new System.Drawing.Point(75, 87);
            this.Leaderboard.Name = "Leaderboard";
            this.Leaderboard.Size = new System.Drawing.Size(125, 33);
            this.Leaderboard.TabIndex = 1;
            this.Leaderboard.Text = "Рейтинг победителей";
            this.Leaderboard.UseVisualStyleBackColor = true;
            // 
            // RulesoftheGame
            // 
            this.RulesoftheGame.Location = new System.Drawing.Point(75, 147);
            this.RulesoftheGame.Name = "RulesoftheGame";
            this.RulesoftheGame.Size = new System.Drawing.Size(125, 33);
            this.RulesoftheGame.TabIndex = 2;
            this.RulesoftheGame.Text = "Правила игры";
            this.RulesoftheGame.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(75, 207);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(125, 33);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 293);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.RulesoftheGame);
            this.Controls.Add(this.Leaderboard);
            this.Controls.Add(this.NewGame);
            this.Name = "Menu";
            this.Text = "Меню игры";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button Leaderboard;
        private System.Windows.Forms.Button RulesoftheGame;
        private System.Windows.Forms.Button Exit;
    }
}