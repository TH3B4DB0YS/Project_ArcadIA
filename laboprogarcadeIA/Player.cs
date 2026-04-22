using System;

namespace laboprogarcadeIA
{
    [Serializable]
    public class Player
    {
        public string GameID { get; set; }
        public int Level { get; set; }
        public int UnlockedGames { get; set; }

        public Player() { }

        public Player(string gameID, int level = 0)
        {
            GameID = gameID;
            Level = level;
            UnlockedGames = level / 15;
        }

        public void AddLevel(int amount = 1)
        {
            Level += amount;
            UnlockedGames = Level / 15;
        }
    }
}