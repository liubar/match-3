using UnityEngine;

namespace Domain
{
    public class SwapState : StateGame
    {
        private IGridCell _cell;
        private Vector3 _vector;

        public SwapState(IGridCell cell, Vector3 vector)
        {
            _cell = cell;
            _vector = vector;
        }

        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            Move(context, _cell, _vector);
            
        }

        /// <summary>
        ///     Try move pieces
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cell">Moveable cell</param>
        /// <param name="vector">Direction of displacement</param>
        private void Move(GameContext context, IGridCell cell, Vector3 vector)
        {
            IGridCell secondCell;

            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            {
                if (vector.x < 0)
                {
                    //direction left
                    if (cell.GridPosition.X == 0)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    secondCell = context.grid.GridCells[cell.GridPosition.X - 1][cell.GridPosition.Y];
                }
                else
                {
                    //direction right
                    if (cell.GridPosition.X == context.grid.GridCells.Length - 1)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    secondCell = context.grid.GridCells[cell.GridPosition.X + 1][cell.GridPosition.Y];
                }
            }
            else
            {
                if (vector.y < 0)
                {
                    //direction bottom
                    if (cell.GridPosition.Y == 0)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    secondCell = context.grid.GridCells[cell.GridPosition.X][cell.GridPosition.Y - 1];
                }
                else
                {
                    //direction top
                    if (cell.GridPosition.Y == context.grid.GridCells.LongLength - 1)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    secondCell = context.grid.GridCells[cell.GridPosition.X][cell.GridPosition.Y + 1];
                }
            }
            
            var swapRes = TrySwap(cell, secondCell);

            if (swapRes)
            {
                context.State = new SwapCheckMatchState(cell, secondCell);
            }
            else
            {
                context.State = new WaitingFillGridState();
            }
        }

        /// <summary>
        ///     Animating the chips at an impossible displacement
        /// </summary>
        /// <param name="cell"></param>
        private void MovementRestricted(IGridCell cell)
        {
            ((MonoBehaviour)cell.Piece).GetComponent<Animator>().Play("Alarm");
            GameContext.Instance.State = new WaitingState();
        }

        /// <summary>
        ///     Trying to move pieces in cells
        /// </summary>
        /// <param name="firstCell">First cell</param>
        /// <param name="secondCell">Second cell</param>
        /// <returns>true == 'moving successfully'</returns>
        private bool TrySwap(IGridCell firstCell, IGridCell secondCell)
        {
            if (secondCell.Piece == null || firstCell.Piece == null)
            {
                return false;
            }

            var f = ((MonoBehaviour)firstCell.Piece).GetComponent<Transform>();
            var s = ((MonoBehaviour)secondCell.Piece).GetComponent<Transform>();

            var temp = f.position;
            f.position = s.position;
            s.position = temp;
            
            return true;
        }
    }
}
