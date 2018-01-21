using UnityEngine;

namespace Domain
{
    public class SwapState : StateGame
    {
        protected override void ChangeState(GameContext context, object[] additionalParams)
        {
            if (additionalParams.Length != 2)
                context.State = new WaitingState();

            var cell = additionalParams[0] as IGridCell;
            var vector = (Vector3)additionalParams[1];

            Move(context, cell, vector);
            
        }

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
                context.State = new WaitingState();
            }
        }

        private void MovementRestricted(IGridCell cell)
        {
            ((MonoBehaviour)cell.Piece).GetComponent<Animator>().Play("Alarm");
            GameContext.Instance.State = new WaitingState();
        }

        private bool TrySwap(IGridCell firstCell, IGridCell secondCell)
        {
            if (secondCell.Piece == null)
            {
                MovementRestricted(firstCell);
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
