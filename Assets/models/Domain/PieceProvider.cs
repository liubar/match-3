using UnityEngine;

namespace Domain
{
    public class PieceProvider : IPieceProvider
    {
        public IGrid Grid { get; set; }

        public void DeletePiece(IGridCell gridCell)
        {
            gridCell.Piece.Clear();
        }

        public void Move(IGridCell gridCell, Vector3 vector)
        {
            IGridCell secondGridCell;

            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            {
                if (vector.x < 0)
                {
                    //direction left
                    if (gridCell.GridPosition.X == 0)
                    {
                        MovementRestricted(gridCell);
                        return;
                    }

                    secondGridCell = Grid.GridCells[gridCell.GridPosition.X - 1][gridCell.GridPosition.Y];
                }
                else
                {
                    //direction right
                    if (gridCell.GridPosition.X == Grid.GridCells.Length - 1)
                    {
                        MovementRestricted(gridCell);
                        return;
                    }

                    secondGridCell = Grid.GridCells[gridCell.GridPosition.X + 1][gridCell.GridPosition.Y];
                }
            }
            else
            {
                if (vector.y < 0)
                {
                    //direction bottom
                    if (gridCell.GridPosition.Y == 0)
                    {
                        MovementRestricted(gridCell);
                        return;
                    }

                    secondGridCell = Grid.GridCells[gridCell.GridPosition.X][gridCell.GridPosition.Y - 1];
                }
                else
                {
                    //direction top
                    if (gridCell.GridPosition.Y == Grid.GridCells.LongLength - 1)
                    {
                        MovementRestricted(gridCell);
                        return;
                    }

                    secondGridCell = Grid.GridCells[gridCell.GridPosition.X][gridCell.GridPosition.Y + 1];
                }
            }

            Swap(gridCell, secondGridCell);
        }

        private void MovementRestricted(IGridCell gridCell)
        {
            ((MonoBehaviour)gridCell.Piece).GetComponent<Animator>().Play("Alarm");
        }

        private void Swap(IGridCell firstGridCell, IGridCell secondGridCell)
        {
            if(firstGridCell.Piece == null || secondGridCell.Piece == null)
                return;

            var f = ((MonoBehaviour) firstGridCell.Piece).GetComponent<Transform>();
            var s = ((MonoBehaviour) secondGridCell.Piece).GetComponent<Transform>();
            
            var temp = f.position;
            f.position = s.position;
            s.position = temp;
        }
    }
}
