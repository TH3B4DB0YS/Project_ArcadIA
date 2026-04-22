using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace laboprogarcadeIA
{
    public class GameDatabase
    {
        private const string DatabasePath = "players_database.xml";
        private List<Player> players;
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));

        public GameDatabase()
        {
            players = new List<Player>();
            LoadDatabase();
        }

        public Player GetOrCreatePlayer(string gameID)
        {
            var player = players.FirstOrDefault(p => p.GameID == gameID);
            if (player == null)
            {
                player = new Player(gameID, 0);
                players.Add(player);
                SaveDatabase();
            }
            return player;
        }

        public void UpdatePlayerLevel(string gameID, int newLevel)
        {
            var player = GetOrCreatePlayer(gameID);
            player.Level = newLevel;
            player.UnlockedGames = newLevel / 15;
            SaveDatabase();
        }

        public List<Player> GetAllPlayers()
        {
            return new List<Player>(players);
        }

        private void LoadDatabase()
        {
            try
            {
                if (File.Exists(DatabasePath))
                {
                    using (FileStream fs = new FileStream(DatabasePath, FileMode.Open))
                    {
                        var loaded = serializer.Deserialize(fs) as List<Player>;
                        if (loaded != null)
                        {
                            players = loaded;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la base de données: {ex.Message}");
                players = new List<Player>();
            }
        }

        private void SaveDatabase()
        {
            try
            {
                using (FileStream fs = new FileStream(DatabasePath, FileMode.Create))
                {
                    serializer.Serialize(fs, players);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde: {ex.Message}");
            }
        }
    }
}