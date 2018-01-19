using System;
using ModelsMatch3;
using ModelsMatch3.interfaces;
using UnityEngine;

namespace DomainLayer
{
    class BoardDefault : IBoard
    {
        private string cellPath = "Prefabs/Cell";
        IGrid grid = new Grid();
        
        IGrid IBoard.grid
        {
            get
            {
                return grid;
            }
        }

        public BoardDefault(int x, int y)
        {
            if (x < 5 || y < 5)
            {
                var errMask = "The minimum size of the grid should be 5 x 5. x = {0}, y = {1}";
                throw new ArgumentException(string.Format(errMask, x, y));
            }

            InitialGrid(x, y);
        }

        private void InitialGrid(int x, int y)
        {
            var cellPrefab = Resources.Load<GameObject>(cellPath);
            grid.Cells = new ICell[x][];

            for (int i = 0; i < x; i++)
            {
                grid.Cells[i] = new ICell[y];

                for (int j = 0; j < y; j++)
                {
                    var position = new Vector3(i, j, 0);
                    var instance = UnityEngine.Object.Instantiate(cellPrefab, position, Quaternion.identity);
                    grid.Cells[i][j] = instance.GetComponent(typeof(ICell)) as ICell;

                    var pPrefab = PieceService.GetRandomPiece();
                    var instPiece = UnityEngine.Object.Instantiate(pPrefab, position, Quaternion.identity);

                    grid.Cells[i][j].Piece = instPiece.GetComponent(typeof(IPiece)) as IPiece;
                }
            }
        }
    }
}
