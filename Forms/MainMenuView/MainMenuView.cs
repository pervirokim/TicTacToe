using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class MainMenuView : Form
    {
        public MainMenuView()
        {
            InitializeComponent();
            if (!File.Exists("settings.json"))
            {
                SettingsModel _settings = new SettingsModel();
                _settings = new SettingsModel();
                _settings.ComputerWord = "O";
                _settings.UserWord = "X";
                _settings.Difficulty = 2;
                _settings.Theme = "default";

                File.WriteAllText("settings.json", JsonConvert.SerializeObject(_settings));

            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuView));
            this.StartGameButton = new System.Windows.Forms.Button();
            this.SettingButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.Color.Aqua;
            this.StartGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StartGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartGameButton.FlatAppearance.BorderSize = 0;
            this.StartGameButton.Location = new System.Drawing.Point(209, 217);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(200);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(200, 40);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start game";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingButton.Location = new System.Drawing.Point(210, 289);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(200, 50, 200, 200);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(200, 40);
            this.SettingButton.TabIndex = 0;
            this.SettingButton.Text = "Settings";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingsGameButton_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InfoButton.Location = new System.Drawing.Point(209, 360);
            this.InfoButton.Margin = new System.Windows.Forms.Padding(200, 50, 200, 200);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(200, 40);
            this.InfoButton.TabIndex = 0;
            this.InfoButton.Text = "Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(223, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenuView
            // 
            this.ClientSize = new System.Drawing.Size(619, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.StartGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe by PerviroKim";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameView gameView = new GameView(this);
            this.Hide();
            gameView.Show();
        }
        private void SettingsGameButton_Click(object sender, EventArgs e)
        {
            SettingsView settingsView = new SettingsView(this);
            this.Hide();
            settingsView.Show();
        }
        private void InfoButton_Click(object sender, EventArgs e)
        {
            InfoModel infoModel = new InfoModel();
            if (File.Exists("info.json"))
            {
                MessageBox.Show(File.ReadAllText("info.json").Replace(',', ' '), "Game Info", MessageBoxButtons.OK);
            }
        }
    }
}
