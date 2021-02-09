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
    public partial class GameView : Form
    {
        TicTacToeService TicTacToeService = new TicTacToeService();
        MainMenuView MainMenuView { get; set; }
        public GameView(MainMenuView instance)
        {
            MainMenuView = instance;
            InitializeComponent();
            SettingsModel settings = TicTacToeService.Settings = JsonConvert.DeserializeObject<SettingsModel>(File.ReadAllText("settings.json"));

            if (File.Exists("save.json"))
            {
                TicTacToeService.Progress = JsonConvert.DeserializeObject<List<ProgressModel>>(File.ReadAllText("save.json"));
                TicTacToeService.CurrentProgress = TicTacToeService.Progress.FirstOrDefault(p => p.Difficulty == settings.Difficulty);
            }
            else
            {
                TicTacToeService.CurrentProgress = new ProgressModel() { Difficulty = 2 };
                TicTacToeService.Progress = new List<ProgressModel>();

                TicTacToeService.Progress.Add(new ProgressModel() { Difficulty = 1 });
                TicTacToeService.Progress.Add(new ProgressModel() { Difficulty = 2 });
                TicTacToeService.Progress.Add(new ProgressModel() { Difficulty = 3 });

                File.WriteAllText("save.json", JsonConvert.SerializeObject(TicTacToeService.Progress));
            }

            TicTacToeService.InitializePlayGround(PlayGroundDisplay, Wins, Loses);
            switch (TicTacToeService.CurrentProgress.Difficulty)
            {
                case 1:
                    DifficultyLabel.ForeColor = Color.Green;
                    Loses.ForeColor = Color.Green;
                    Wins.ForeColor = Color.Green;
                    break;
                case 2:
                    DifficultyLabel.ForeColor = Color.Orange;
                    Loses.ForeColor = Color.Orange;
                    Wins.ForeColor = Color.Orange;
                    break;
                case 3:
                    DifficultyLabel.ForeColor = Color.Violet;
                    Loses.ForeColor = Color.Violet;
                    Wins.ForeColor = Color.Violet;
                    break;
            }
            DifficultyLabel.Text = "Difficulty : " + TicTacToeService.CurrentProgress.Difficulty.ToString();
            TicTacToeService.StartGame();


        }
        private void PlayerClick(object sender, DataGridViewCellEventArgs e)
        {
            TicTacToeService.PlayerStep(e.RowIndex, e.ColumnIndex);
        }

    }
}
