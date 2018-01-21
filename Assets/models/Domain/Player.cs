using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        
        public Player(string name, int score, int bonus)
        {
            Name = name;
            Score = score;
            Bonus = bonus;
        }
        
        public string Name { get; set; }
        public int Score { get; private set; }
        public int Bonus { get; set; }

        public void AddScores(IEnumerable<IMatch> matchs)
        {
            Score = matchs.Select(o => o.GetScore()).Sum();
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;

            if (player == null)
            {
                throw new ArgumentException("Player.Equals(obj) --> obj must be Player type");
            }

            return Name.Equals(player.Name);
        }
    }
}