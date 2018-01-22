using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Domain
{
    public class Player
    {
        private TextMesh _scoreObj;
        private string scoreTag = "Score";
        private string scoreMask = "Score: {0}";

        public Player(string name, int score, int bonus)
        {
            Name = name;
            Score = score;
            Bonus = bonus;
            _scoreObj = GameObject.FindGameObjectsWithTag(scoreTag).First().GetComponent<TextMesh>();
        }
        
        public string Name { get; set; }
        public int Score { get; private set; }
        public int Bonus { get; set; }

        /// <summary>
        ///     Add scores for matches
        /// </summary>
        /// <param name="matches">Counted matches</param>
        public void AddScores(IEnumerable<IMatch> matches)
        {
            Score += matches.Select(o => o.GetScore()).Sum();
            _scoreObj.text = string.Format(scoreMask, Score);
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