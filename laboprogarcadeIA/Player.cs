using System;

namespace laboprogarcadeIA
{
    [Serializable]
    public class Player
    {
        public string GameID { get; set; }
        public int Level { get; set; }
        public int UnlockedGames { get; set; }
       
        public int NbGames { get; set; }

        public Player() { }

        public Player(string gameID, int level = 0)
        {
            GameID = gameID;
            Level = level;
            UnlockedGames = level / Level+5;
        }

        public void AddLevel(int amount = 1)
        {
            if (Level<101) 
            {
                Level += amount;
                UnlockedGames = Level / Level+5;
            }

            else
            {
               LevelMaximum();

            }
        }
        public void NextGame()
        {
            NbGames = UnlockedGames;

        }
        public void Reset()
        {
            Level = 0;
            UnlockedGames = 0;
            NbGames = 0;
        }
        public void LevelMaximum()
        {
            Level = 100;
        }
    }
}