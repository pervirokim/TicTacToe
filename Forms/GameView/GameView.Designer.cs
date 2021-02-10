using System.Windows.Forms;

namespace tic_tac_toe
{
    partial class GameView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {

            MainMenuView.Show();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Wins = new System.Windows.Forms.Label();
            this.Loses = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayGroundDisplay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PlayGroundDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // Wins
            // 
            this.Wins.AutoSize = true;
            this.Wins.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Wins.Location = new System.Drawing.Point(170, 47);
            this.Wins.Name = "Wins";
            this.Wins.Size = new System.Drawing.Size(78, 25);
            this.Wins.TabIndex = 1;
            this.Wins.Text = "Wins : 0";
            // 
            // Loses
            // 
            this.Loses.AutoSize = true;
            this.Loses.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Loses.Location = new System.Drawing.Point(170, 72);
            this.Loses.Name = "Loses";
            this.Loses.Size = new System.Drawing.Size(82, 25);
            this.Loses.TabIndex = 1;
            this.Loses.Text = "Loses : 0";
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DifficultyLabel.Location = new System.Drawing.Point(170, 97);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(124, 25);
            this.DifficultyLabel.TabIndex = 2;
            this.DifficultyLabel.Text = "Difficulty :  3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 50;
            // 
            // PlayGroundDisplay
            // 
            this.PlayGroundDisplay.AllowUserToAddRows = false;
            this.PlayGroundDisplay.AllowUserToDeleteRows = false;
            this.PlayGroundDisplay.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PlayGroundDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayGroundDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayGroundDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.PlayGroundDisplay.Cursor = System.Windows.Forms.Cursors.Default;
            this.PlayGroundDisplay.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlayGroundDisplay.Location = new System.Drawing.Point(10, 11);
            this.PlayGroundDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayGroundDisplay.Name = "PlayGroundDisplay";
            this.PlayGroundDisplay.ReadOnly = true;
            this.PlayGroundDisplay.RowHeadersWidth = 51;
            this.PlayGroundDisplay.Size = new System.Drawing.Size(184, 181);
            this.PlayGroundDisplay.TabIndex = 0;
            this.PlayGroundDisplay.Text = "dataGridView1";
            this.PlayGroundDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerClick);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 174);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.Loses);
            this.Controls.Add(this.Wins);
            this.Controls.Add(this.PlayGroundDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe by PerviroKim";
            ((System.ComponentModel.ISupportInitialize)(this.PlayGroundDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public System.Windows.Forms.DataGridView PlayGroundDisplay;
        private System.Windows.Forms.Label Wins;
        private System.Windows.Forms.Label Loses;
        private Label DifficultyLabel;
        private DataGridViewButtonColumn Column1;
        private DataGridViewButtonColumn Column2;
        private DataGridViewButtonColumn Column3;
    }
}

