using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public class TicTacToeService
    {
        private enum GameTurn
        {
            Player = 1,
            Computer = 2
        }
        private enum GameStatus
        {
            Win = 1,
            Lose = 2,
            Tie = 3
        }
        private string[,] PlayGround { get; set; }
        private int loseCount = 0;
        private int winsCount = 0;
        private Label Win { get; set; }
        private Label Lose { get; set; }
        private string UserWord { get; set; }
        private string ComputerWord { get; set; }
        private GameStatus Status { get; set; }
        private GameTurn CurrentTurn { get; set; }
        public DataGridView PlayGroundToDisplay { get; set; }
        public InfoModel Info { get; set; }
        public ProgressModel Progress { get; set; }

        public void InitializePlayGround(DataGridView playground, Label win, Label lose)
        {
            PlayGround = new string[3, 3];
            PlayGroundToDisplay = playground;
            PlayGroundToDisplay.ColumnHeadersVisible = false;
            PlayGroundToDisplay.RowHeadersVisible = false;

            Win = win;
            Lose = lose;
            winsCount = Progress.Wins;
            loseCount = Progress.Loses;
            Win.Text = "Wins : " + winsCount;
            Lose.Text = "Loses : " + loseCount;


            for (int i = 0; i < 3; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 50;
                row.ReadOnly = true;
                row.Resizable= System.Windows.Forms.DataGridViewTriState.False;
                PlayGroundToDisplay.Rows.Add(row);
            }

            UserWord = "X";
            ComputerWord = "O";

          

            EmptyPlayGround();
            GridDataUpdate();

            RandomTurn();

        }
        public void RandomTurn()
        {
            Random random = new Random();
            switch (random.Next(0, 3))
            {
                case 1:
                    CurrentTurn = GameTurn.Player;
                    break;
                case 2:
                    CurrentTurn = GameTurn.Computer;
                    break;
            }
        }
        public void StartGame()
        {
            Step();
        }

        private void GridDataUpdate()
        {
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    PlayGroundToDisplay.Rows[i].Cells[j].Value = PlayGround[i, j];
                }
            }

        }

        private void Step(object obj = null)
        {

            //stepCount++;
            if (CurrentTurn == GameTurn.Player)
            {
                WaitForPlayerStep();

            }

            else if (CurrentTurn == GameTurn.Computer)
            {
                ComputerStep();
                CurrentTurn = GameTurn.Player;
            }

            GridDataUpdate();

            if (IsGameOver(UserWord))
            {
                Status = GameStatus.Win;
                GameEnd();
                return;
            }
            else if (IsGameOver(ComputerWord))
            {
                Status = GameStatus.Lose;
                GameEnd();
                return;
            }
            else if (IsGameOver())
            {
                Status = GameStatus.Tie;
                GameEnd();
                return;
            }

        }
        private void WaitForPlayerStep()
        {
            return;
        }
        private bool IsGameOver()
        {
            bool flag = true;
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    if (String.IsNullOrEmpty(PlayGround[i, j]))
                        flag = false;
                }
            }
            return flag;
        }
        private bool IsGameOver(string word)
        {

            //for rows
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                int rowCount = 0;
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    if (PlayGround[i, j] == word)
                        rowCount++;
                    if (rowCount == 3)
                        return true;
                }
            }
            //for columns
            for (int i = 0; i < PlayGround.GetLength(1); i++)
            {
                int columnCount = 0;
                for (int j = 0; j < PlayGround.GetLength(0); j++)
                {
                    if (PlayGround[j, i] == word)
                        columnCount++;
                    if (columnCount == 3)
                        return true;
                }
            }
            //for curve TopLine
            int curveCount = 0;
            for (int i = 0; i < PlayGround.GetLength(1); i++)
            {
                if (PlayGround[i, i] == word)
                    curveCount++;
                if (curveCount == 3)
                    return true;

            }
            //for curve bottomLine
            curveCount = 0;
            for (int j = 0, i = 2; j < PlayGround.GetLength(1); j++, i--)
            {
                if (PlayGround[i, j] == word)
                    curveCount++;
            }
            if (curveCount == 3)
                return true;

            return false;
        }


        private void ComputerStep()
        {
            if (!chekForDouble(ComputerWord))
            {
                if (!chekForDouble(UserWord))
                {
                    if (!chekForCurveFirs())
                    {

                        if (String.IsNullOrEmpty(PlayGround[1, 1]))
                        {
                            PlayGround[1, 1] = ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[0, 0]))
                        {
                            PlayGround[0, 0] = ComputerWord; return;

                        }

                        else if (String.IsNullOrEmpty(PlayGround[0, 2]))
                        {
                            PlayGround[0, 2] = ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[2, 0]))
                        {
                            PlayGround[2, 0] = ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[2, 2]))
                        {
                            PlayGround[2, 2] = ComputerWord; return;
                        }

                        simpleChoise();
                    }
                }

            }

        }


        public void simpleChoise()
        {
            for (int i = 0; i < PlayGround.GetLength(0); i++)
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                    if (String.IsNullOrEmpty(PlayGround[i, j]))
                    {
                        PlayGround[i, j] = ComputerWord;
                        return;
                    }
        }

        public bool chekForDouble(string word)
        {
            //for rows
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                int rowCount = 0;
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    if (PlayGround[i, j] == word)
                        rowCount++;
                    if (rowCount == 2)
                    {
                        for (int g = 0; g < PlayGround.GetLength(1); g++)
                        {
                            if (String.IsNullOrEmpty(PlayGround[i, g]))
                            {
                                PlayGround[i, g] = ComputerWord;
                                return true;
                            }
                        }

                    }



                }
            }
            //for columns
            for (int i = 0; i < PlayGround.GetLength(1); i++)
            {
                int columnCount = 0;
                for (int j = 0; j < PlayGround.GetLength(0); j++)
                {
                    if (PlayGround[j, i] == word)
                        columnCount++;
                    if (columnCount == 2)
                    {
                        for (int g = 0; g < PlayGround.GetLength(0); g++)
                        {
                            if (String.IsNullOrEmpty(PlayGround[g, i]))
                            {
                                PlayGround[g, i] = ComputerWord;
                                return true;
                            }
                        }

                    }

                }
            }
            //for curve TopLine
            int curveCount = 0;
            for (int i = 0; i < PlayGround.GetLength(1); i++)
            {
                if (PlayGround[i, i] == word)
                    curveCount++;
                if (curveCount == 2)
                {
                    for (int g = 0; g < PlayGround.GetLength(0); g++)
                    {
                        if (String.IsNullOrEmpty(PlayGround[g, g]))
                        {
                            PlayGround[g, g] = ComputerWord;
                            return true;
                        }
                    }

                }

            }
            //for curve bottomLine
            curveCount = 0;
            for (int j = 0, i = 2; j < PlayGround.GetLength(1); j++, i--)
            {
                if (PlayGround[i, j] == word)
                    curveCount++;
            }
            if (curveCount == 2)
                for (int j = 0, i = 2; j < PlayGround.GetLength(1); j++, i--)
                {
                    if (String.IsNullOrEmpty(PlayGround[i, j]))
                    {
                        PlayGround[i, j] = ComputerWord;
                        return true;
                    }


                }
            return false;
        }

        public void PlayerStep(int i, int j)
        {
            if (String.IsNullOrEmpty(PlayGround[i, j]))
            {
                PlayGround[i, j] = UserWord;
                CurrentTurn = GameTurn.Computer;
                Step();
            }


        }

        public bool chekForCurveFirs()
        {
            //todo
            int userWordsCounter = 0;
            int computerWordsCounter = 0;
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    if (PlayGround[i, j] == UserWord)
                        userWordsCounter++;
                    if (PlayGround[i, j] == ComputerWord)
                        computerWordsCounter++;
                }
            }

            if (userWordsCounter == 2 && computerWordsCounter == 1)
            {
                if (PlayGround[0, 0] == UserWord)
                {
                    PlayGround[0, 1] = ComputerWord;
                    return true;
                }

                if (PlayGround[0, 2] == UserWord)
                {
                    PlayGround[0, 1] = ComputerWord;
                    return true;
                }
                if (PlayGround[2, 0] == UserWord)
                {
                    PlayGround[2, 1] = ComputerWord;
                    return true;
                }
                if (PlayGround[2, 2] == UserWord)
                {
                    PlayGround[2, 1] = ComputerWord;
                    return true;
                }
            }
            return false;

        }
        public void EmptyPlayGround()
        {
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    PlayGround[i, j] = String.Empty;
                }
            }

        }
        public void GameEnd()
        {
            string message = "";
            if (Status == GameStatus.Win)
            {
                winsCount++;
                message += "You Win!";
                Win.Text = "Wins : " + winsCount;
            }
            else if (Status == GameStatus.Lose)
            {
                loseCount++;
                message += "You Lose!";
                Lose.Text = "Loses : " + loseCount;
            }
            else if (Status == GameStatus.Tie)
            {
                message += "Standoff";
            }
            MessageBox.Show(message, "Game Over");


            Progress.Loses = loseCount;
            Progress.Wins = winsCount;
            File.WriteAllText("save.json", JsonConvert.SerializeObject(Progress));

            EmptyPlayGround();
            GridDataUpdate();
            RandomTurn();
            Step();



        }
    }
}
