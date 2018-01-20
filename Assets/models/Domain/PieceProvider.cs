using UnityEngine;

namespace Domain
{
    public class PieceProvider : IPieceProvider
    {
        public IGrid Grid { get; set; }

        public void Move(ICell cell, Vector3 vector)
        {
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

                    Swap(cell, Grid.Cells[cell.GridPosition.X - 1][cell.GridPosition.Y]);
                }
                else
                {
                    //direction right
                    if (cell.GridPosition.X == Grid.Cells.Length - 1)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    Swap(cell, Grid.Cells[cell.GridPosition.X + 1][cell.GridPosition.Y]);
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

                    Swap(cell, Grid.Cells[cell.GridPosition.X][cell.GridPosition.Y - 1]);
                }
                else
                {
                    //direction top
                    if (cell.GridPosition.Y == Grid.Cells.LongLength - 1)
                    {
                        MovementRestricted(cell);
                        return;
                    }

                    Swap(cell, Grid.Cells[cell.GridPosition.X][cell.GridPosition.Y + 1]);
                }
            }
        }

        private void MovementRestricted(ICell cell)
        {

        }

        private void Swap(ICell firstCell, ICell SecondCell)
        {
            
            var p = ((MonoBehaviour)firstCell.Piece);
            p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            p.GetComponent<Animator>().Play("SwapBackTop");
            

        }
    }
}
