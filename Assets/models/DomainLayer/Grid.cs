using System;
using UnityEngine;

namespace DomainLayer
{
    public class Grid
    {
        private Cell[,] grid;

        public Grid(int x, int y)
        {
            if (x < 5 || y < 5)
            {
                var errMask = "The minimum size of the grid should be 5 x 5. x = {0}, y = {1}";
                throw new ArgumentException(string.Format(errMask, x, y));
            }

            InitialGrid(x, y);
        }

        void InitialGrid(int x, int y)
        {
            grid = new Cell[x, y];
            var cellPrefab = Resources.Load<GameObject>("Prefabs/Cell");

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var obj = UnityEngine.Object.Instantiate(cellPrefab, new Vector3(i, j, 0), Quaternion.identity);
                    grid[i, j] = obj.GetComponent(typeof(Cell)) as Cell;
                    grid[i, j].FillPiece();
                }
            }
        }
    }
}