using System.Collections.Generic;
using Domain;

namespace App
{
    public class LevelManager
    {
        private Dictionary<Player, List<ILevel>> players = new Dictionary<Player, List<ILevel>>();
        
        public ILevel CurrentLevel { get; set; }
        public Player CurrentPlayer { get; set; }

        public bool AddPlayer(string name)
        {
            var player = new Player(name, 0, 0);

            if (players.ContainsKey(player))
            {
                return false;
            }

            players.Add(player, GetDefaultLevels());

            return true;
        }

        public List<ILevel> GetPlayerLevels()
        {
            return GetPlayerLevels(this.CurrentPlayer);
        }

        public List<ILevel> GetPlayerLevels(Player player)
        {
            if (!players.ContainsKey(player))
            {
                throw new KeyNotFoundException("Player \"" + player.Name + "\" is not regestered");
            }

            return players[player];
        }

        private List<ILevel> GetDefaultLevels()
        {
            return new List<ILevel>
            {
                new Level_1_1(),
                new Level_1_1(),
                new Level_1_1()
            };
        }
    }
}