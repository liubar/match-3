using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class MatchState : StateGame
    {
        private IEnumerable<IMatch> _matchs;

        public MatchState(IEnumerable<IMatch> matchs)
        {
            _matchs = matchs;
        }

        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            context.player.AddScores(_matchs);
            var matchCells = _matchs.Select(el => el.GetCells());

            //delete finded pieces
            foreach (var gridCells in matchCells)
            {
                gridCells.ForEach(ob => ob.Piece.Clear());
            }

            context.State = new WaitingFillGridState();
        }
    }
}
