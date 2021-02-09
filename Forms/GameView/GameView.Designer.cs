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
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PlayGroundDisplay = new System.Windows.Forms.DataGridView();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayGroundDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // Wins
            // 
            this.Wins.AutoSize = true;
            this.Wins.Location = new System.Drawing.Point(217, 202);
            this.Wins.Name = "Wins";
            this.Wins.Size = new System.Drawing.Size(60, 20);
            this.Wins.TabIndex = 1;
            this.Wins.Text = "Wins : 0";
            // 
            // Loses
            // 
            this.Loses.AutoSize = true;
            this.Loses.Location = new System.Drawing.Point(12, 202);
            this.Loses.Name = "Loses";
            this.Loses.Size = new System.Drawing.Size(64, 20);
            this.Loses.TabIndex = 1;
            this.Loses.Text = "Loses : 0";
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
            this.PlayGroundDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.PlayGroundDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayGroundDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.PlayGroundDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayGroundDisplay.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlayGroundDisplay.Location = new System.Drawing.Point(67, 12);
            this.PlayGroundDisplay.Name = "PlayGroundDisplay";
            this.PlayGroundDisplay.ReadOnly = true;
            this.PlayGroundDisplay.RowHeadersWidth = 51;
            this.PlayGroundDisplay.Size = new System.Drawing.Size(153, 187);
            this.PlayGroundDisplay.TabIndex = 0;
            this.PlayGroundDisplay.Text = "dataGridView1";
            this.PlayGroundDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerClick);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DifficultyLabel.Location = new System.Drawing.Point(92, 256);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(99, 20);
            this.DifficultyLabel.TabIndex = 2;
            this.DifficultyLabel.Text = "Difficulty :  3";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 285);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.Loses);
            this.Controls.Add(this.Wins);
            this.Controls.Add(this.PlayGroundDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private Label DifficultyLabel;

        public event System.Windows.Forms.DataGridViewCellEventHandler CellClick;
    }
}

