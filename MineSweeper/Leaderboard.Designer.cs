namespace MineSweeper
{
    partial class Leaderboard
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.playersTable = new System.Windows.Forms.DataGridView();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.easy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.playersTable, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.02347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.97652F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 345);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(90, 2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(306, 47);
            this.title.TabIndex = 0;
            this.title.Text = "Доска лидеров";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playersTable
            // 
            this.playersTable.AutoGenerateColumns = false;
            this.playersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.easy,
            this.normal,
            this.hard});
            this.playersTable.DataSource = this.playerBindingSource;
            this.playersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersTable.Location = new System.Drawing.Point(3, 54);
            this.playersTable.Name = "playersTable";
            this.playersTable.RowHeadersWidth = 51;
            this.playersTable.RowTemplate.Height = 24;
            this.playersTable.Size = new System.Drawing.Size(480, 288);
            this.playersTable.TabIndex = 1;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(MineSweeper.Player);
            // 
            // easy
            // 
            this.easy.HeaderText = "Легко";
            this.easy.MinimumWidth = 6;
            this.easy.Name = "easy";
            this.easy.Width = 125;
            // 
            // normal
            // 
            this.normal.HeaderText = "Hормально";
            this.normal.MinimumWidth = 6;
            this.normal.Name = "normal";
            this.normal.Width = 125;
            // 
            // hard
            // 
            this.hard.HeaderText = "Cложно";
            this.hard.MinimumWidth = 6;
            this.hard.Name = "hard";
            this.hard.Width = 125;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn easy;
        private System.Windows.Forms.DataGridViewTextBoxColumn normal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hard;
        public System.Windows.Forms.DataGridView playersTable;
    }
}