using System;

namespace tic_tac_toe
{
    public enum GameTurn
    {
        Player = 1,
        Computer = 2,
        Random = 3
    }
    public enum GameStatus
    {
        Win = 1,
        Lose = 2,
        Tie = 3
    }
    public class InfoModel
    {
        public string Version { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdated { get; set; }
        public string ContactInfo { get; set; }
    }
    public class ProgressModel
    {
        public int Loses { get; set; }
        public int Wins { get; set; }
        public int Difficulty { get; set; }
    }
    public class SettingsModel
    {
        public int Difficulty { get; set; }
        public string Theme { get; set; }
        public string UserWord { get; set; }
        public string ComputerWord { get; set; }
        public GameTurn GameTurn { get; set; }
    }

}