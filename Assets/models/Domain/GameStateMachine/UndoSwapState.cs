using UnityEngine;

namespace Domain
{
    public class UndoSwapState : StateGame
    {
        private IGridCell _firstCell;
        private IGridCell _secondCell;

        public UndoSwapState(IGridCell firstCell, IGridCell secondCell)
        {
            _firstCell = firstCell;
            _secondCell = secondCell;
        }

        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            Swap(_firstCell, _secondCell);
            context.State = new WaitingState();
        }

        private void Swap(IGridCell firstCell, IGridCell secondCell)
        {
            var f = ((MonoBehaviour)firstCell.Piece).GetComponent<Transform>();
            var s = ((MonoBehaviour)secondCell.Piece).GetComponent<Transform>();

            var temp = f.position;
            f.position = s.position;
            s.position = temp;
        }
    }
}
