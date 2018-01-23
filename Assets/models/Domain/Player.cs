using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        private int _score;

        public event Action<int> updateScore;

        public string Name { get; set; }
        public int Bonus { get; set; }

        public Player(string name, int bonus)
        {
            Name = name;
            Bonus = bonus;
        }

        /// <summary>
        ///     Add scores for matches
        /// </summary>
        /// <param name="matches">Counted matches</param>
        public void AddScores(IEnumerable<IMatch> matches)
        {
            _score += matches.Select(o => o.GetScore()).Sum();

            if (updateScore != null)
                updateScore.Invoke(_score);
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