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
    public partial class AppWindow : Form
    {
        TicTacToeService TicTacToeService = new TicTacToeService();
        public AppWindow()
        {
            InitializeComponent();

            if (File.Exists("info.json"))
                TicTacToeService.Info = JsonConvert.DeserializeObject<InfoModel>(File.ReadAllText("info.json"));


            ProgressModel progressModel = new ProgressModel();
            if (File.Exists("save.json"))
                TicTacToeService.Progress = JsonConvert.DeserializeObject<ProgressModel>(File.ReadAllText("save.json"));
            else
            {
                TicTacToeService.Progress = new ProgressModel();
                File.WriteAllText("save.json", JsonConvert.SerializeObject(progressModel));
            }

            TicTacToeService.InitializePlayGround(PlayGroundDisplay, Wins, Loses);
            TicTacToeService.StartGame();


        }
        private void PlayerClick(object sender, DataGridViewCellEventArgs e)
        {
            TicTacToeService.PlayerStep(e.RowIndex, e.ColumnIndex);
        }

        private void info_Click(object sender, EventArgs e)
        {
            string jsonInfo = JsonConvert.SerializeObject(TicTacToeService.Info);
            MessageBox.Show(jsonInfo.Replace(',' , ' '), "Game Info", MessageBoxButtons.OK);
        }
    }
}
