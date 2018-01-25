using Domain;
using UnityEngine;

namespace App
{
    public abstract class BaseMoveController : IMoveController
    {
        private IGridCell _lastCell;

        public void Update()
        {
            if (InputIsActive())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(GetPosition());

                if (Physics.Raycast(ray, out hit))
                {
                    // clicked cell
                    var cell = hit.collider.gameObject.GetComponent<IGridCell>();

                    if (cell == null)
                    {
                        return;
                    }

                    if (_lastCell == null)
                    {
                        _lastCell = cell;
                        return;
                    }

                    if (_lastCell.GridPosition.X == cell.GridPosition.X)
                    {
                        var directionalY = cell.GridPosition.Y - _lastCell.GridPosition.Y;

                        // The pieces are on the same line
                        if (Mathf.Abs(directionalY) == 1)
                        {
                            _lastCell.MovePiece(new Vector3(0, directionalY, 0));
                        }
                    }

                    if (_lastCell.GridPosition.Y == cell.GridPosition.Y)
                    {
                        var directionalX = cell.GridPosition.X - _lastCell.GridPosition.X;

                        // The pieces are on the same column
                        if (Mathf.Abs(directionalX) == 1)
                        {
                            _lastCell.MovePiece(new Vector3(directionalX, 0, 0));
                        }
                    }

                    _lastCell = null;
                }
            }
        }

        protected abstract bool InputIsActive();
        protected abstract Vector3 GetPosition();
    }
}
