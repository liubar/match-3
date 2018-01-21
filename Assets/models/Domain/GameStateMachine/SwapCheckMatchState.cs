using System.Linq;

namespace Domain
{
    public class SwapCheckMatchState : StateGame
    {
        private IGridCell _firstCell;
        private IGridCell _secondCell;

        public SwapCheckMatchState(IGridCell firstCell, IGridCell secondCell)
        {
            _firstCell = firstCell;
            _secondCell = secondCell;
        }

        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            var findMatchs = context.matchChecker.CheckMatch(context.grid);

            if (findMatchs.Any())
            {
                context.State = new MatchState(findMatchs);
            }
            else
            {
                context.State = new UndoSwapState(_firstCell, _secondCell);
            }
        }
    }
}
