using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public class TicTacToeService
    {
        public TicTacToeService()
        {
        }
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
        private Label WinLabel { get; set; }
        private Label LoseLabel { get; set; }
        public SettingsModel Settings { get; set; }

        private GameStatus Status { get; set; }
        private GameTurn CurrentTurn { get; set; }
        public DataGridView PlayGroundToDisplay { get; set; }
        public List<ProgressModel> Progress { get; set; }
        public ProgressModel CurrentProgress { get; set; }

        public void InitializePlayGround(DataGridView playground, Label win, Label lose)
        {
            PlayGround = new string[3, 3];
            PlayGroundToDisplay = playground;
            PlayGroundToDisplay.ColumnHeadersVisible = false;
            PlayGroundToDisplay.RowHeadersVisible = false;

            WinLabel = win;
            LoseLabel = lose;

            WinLabel.Text = "Wins : " + CurrentProgress.Wins;
            LoseLabel.Text = "Loses : " + CurrentProgress.Loses;


            for (int i = 0; i < 3; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 50;
                row.ReadOnly = true;
                row.Resizable = System.Windows.Forms.DataGridViewTriState.False;
                PlayGroundToDisplay.Rows.Add(row);
            }




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

            if (IsGameOver(Settings.UserWord))
            {
                Status = GameStatus.Win;
                GameEnd();
                return;
            }
            else if (IsGameOver(Settings.ComputerWord))
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
            if (Settings.Difficulty >= 1 && !chekForDouble(Settings.ComputerWord))
            {
                if (Settings.Difficulty >= 2 && !chekForDouble(Settings.UserWord))
                {
                    if (Settings.Difficulty == 3 && !chekForCurveFirst())
                    {

                        if (String.IsNullOrEmpty(PlayGround[1, 1]))
                        {
                            PlayGround[1, 1] = Settings.ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[0, 0]))
                        {
                            PlayGround[0, 0] = Settings.ComputerWord; return;

                        }

                        else if (String.IsNullOrEmpty(PlayGround[0, 2]))
                        {
                            PlayGround[0, 2] = Settings.ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[2, 0]))
                        {
                            PlayGround[2, 0] = Settings.ComputerWord; return;
                        }

                        else if (String.IsNullOrEmpty(PlayGround[2, 2]))
                        {
                            PlayGround[2, 2] = Settings.ComputerWord; return;
                        }
                        eptyCellChoise(); return;

                    }
                    if (Settings.Difficulty == 2)
                        simpleChoise(); return;
                }
                if (Settings.Difficulty == 1)
                    simpleChoise(); return;
            }


        }


        private void simpleChoise()
        {
            Random random = new Random();
            int i = random.Next(0, PlayGround.GetLength(0));
            int j = random.Next(0, PlayGround.GetLength(0));
            if (String.IsNullOrEmpty(PlayGround[i, j]))
            {
                PlayGround[i, j] = Settings.ComputerWord;
                return;
            }
            else simpleChoise();
        }
        private void eptyCellChoise()
        {
            for (int i = 0; i < PlayGround.GetLength(0); i++)
                for (int j = 0; j < PlayGround.GetLength(0); j++)
                    if (String.IsNullOrEmpty(PlayGround[i, j]))
                    {
                        PlayGround[i, j] = Settings.ComputerWord;
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
                                PlayGround[i, g] = Settings.ComputerWord;
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
                                PlayGround[g, i] = Settings.ComputerWord;
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
                            PlayGround[g, g] = Settings.ComputerWord;
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
                        PlayGround[i, j] = Settings.ComputerWord;
                        return true;
                    }


                }
            return false;
        }

        public void PlayerStep(int i, int j)
        {
            if (String.IsNullOrEmpty(PlayGround[i, j]))
            {
                PlayGround[i, j] = Settings.UserWord;
                CurrentTurn = GameTurn.Computer;
                Step();
            }


        }

        public bool chekForCurveFirst()
        {
            //todo
            int userWordsCounter = 0;
            int computerWordsCounter = 0;
            for (int i = 0; i < PlayGround.GetLength(0); i++)
            {
                for (int j = 0; j < PlayGround.GetLength(1); j++)
                {
                    if (PlayGround[i, j] == Settings.UserWord)
                        userWordsCounter++;
                    if (PlayGround[i, j] == Settings.ComputerWord)
                        computerWordsCounter++;
                }
            }

            if (userWordsCounter == 2 && computerWordsCounter == 1)
            {
                if (PlayGround[0, 0] == Settings.UserWord)
                {
                    PlayGround[0, 1] = Settings.ComputerWord;
                    return true;
                }

                if (PlayGround[0, 2] == Settings.UserWord)
                {
                    PlayGround[0, 1] = Settings.ComputerWord;
                    return true;
                }
                if (PlayGround[2, 0] == Settings.UserWord)
                {
                    PlayGround[2, 1] = Settings.ComputerWord;
                    return true;
                }
                if (PlayGround[2, 2] == Settings.UserWord)
                {
                    PlayGround[2, 1] = Settings.ComputerWord;
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
                CurrentProgress.Wins++;
                message += "You Win!";
                WinLabel.Text = "Wins : " + CurrentProgress.Wins;
            }
            else if (Status == GameStatus.Lose)
            {
                CurrentProgress.Loses++;
                message += "You Lose!";
                LoseLabel.Text = "Loses : " + CurrentProgress.Loses;
            }
            else if (Status == GameStatus.Tie)
            {
                message += "Standoff";
            }
            MessageBox.Show(message, "Game Over");

            ProgressModel progressTosave = this.Progress.Find(p => p.Difficulty == CurrentProgress.Difficulty);
            progressTosave.Loses = CurrentProgress.Loses;
            progressTosave.Wins = CurrentProgress.Wins;

            File.WriteAllText("save.json", JsonConvert.SerializeObject(Progress));

            EmptyPlayGround();
            GridDataUpdate();
            RandomTurn();
            Step();



        }
    }
}
