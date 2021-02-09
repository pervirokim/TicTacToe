﻿using Newtonsoft.Json;
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
    public partial class SettingsView : Form
    {
        MainMenuView MainMenuView { get; set; }
        SettingsModel Settings { get; set; }
        public SettingsView(MainMenuView instance)
        {
            MainMenuView = instance;
            Settings = JsonConvert.DeserializeObject<SettingsModel>(File.ReadAllText("settings.json"));
           
            InitializeComponent();

            DifficultyBox.Text = Settings.Difficulty.ToString();
            ThemeBox.Text = Settings.Theme;
            PSymbolBox.Text = Settings.UserWord;
            CSymbolBox.Text = Settings.ComputerWord;

        }

        private void InitializeComponent()
        {
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DifficultyBox = new System.Windows.Forms.ComboBox();
            this.ThemeBox = new System.Windows.Forms.ComboBox();
            this.PSymbolBox = new System.Windows.Forms.TextBox();
            this.CSymbolBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Location = new System.Drawing.Point(299, 182);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(126, 39);
            this.SaveSettingsButton.TabIndex = 0;
            this.SaveSettingsButton.Text = "Save";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Difficulty ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Theme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(263, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Player symbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(263, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Computer symbol";
            // 
            // DifficultyBox
            // 
            this.DifficultyBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DifficultyBox.FormattingEnabled = true;
            this.DifficultyBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.DifficultyBox.Location = new System.Drawing.Point(149, 34);
            this.DifficultyBox.Name = "DifficultyBox";
            this.DifficultyBox.Size = new System.Drawing.Size(59, 28);
            this.DifficultyBox.TabIndex = 2;
            // 
            // ThemeBox
            // 
            this.ThemeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ThemeBox.FormattingEnabled = true;
            this.ThemeBox.Items.AddRange(new object[] {
            "default"});
            this.ThemeBox.Location = new System.Drawing.Point(121, 80);
            this.ThemeBox.Name = "ThemeBox";
            this.ThemeBox.Size = new System.Drawing.Size(87, 28);
            this.ThemeBox.TabIndex = 2;
            // 
            // PSymbolBox
            // 
            this.PSymbolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PSymbolBox.Location = new System.Drawing.Point(504, 33);
            this.PSymbolBox.MaxLength = 1;
            this.PSymbolBox.Name = "PSymbolBox";
            this.PSymbolBox.Size = new System.Drawing.Size(43, 27);
            this.PSymbolBox.TabIndex = 3;
            // 
            // CSymbolBox
            // 
            this.CSymbolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CSymbolBox.Location = new System.Drawing.Point(504, 85);
            this.CSymbolBox.MaxLength = 1;
            this.CSymbolBox.Name = "CSymbolBox";
            this.CSymbolBox.Size = new System.Drawing.Size(43, 27);
            this.CSymbolBox.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(431, 182);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(126, 39);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelSettingsButton_Click);
            // 
            // SettingsView
            // 
            this.ClientSize = new System.Drawing.Size(569, 233);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CSymbolBox);
            this.Controls.Add(this.PSymbolBox);
            this.Controls.Add(this.ThemeBox);
            this.Controls.Add(this.DifficultyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveSettingsButton);
            this.Name = "SettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe by PerviroKim";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            SettingsModel settingsToSave = new SettingsModel();
            settingsToSave.Difficulty = Convert.ToInt32(DifficultyBox.Text);
            settingsToSave.Theme = ThemeBox.Text;
            settingsToSave.UserWord = PSymbolBox.Text;
            settingsToSave.ComputerWord = CSymbolBox.Text;

            File.WriteAllText("settings.json", JsonConvert.SerializeObject(settingsToSave));

            this.Close();
            MainMenuView.Show();
        }

        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenuView.Show();
        }
    }
}
