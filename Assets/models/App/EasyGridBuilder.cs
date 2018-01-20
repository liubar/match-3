using System;
using Domain;
using UnityEngine;

namespace App
{
    public class EasyGridBuilder : IGridBuilder
    {
        private string cellPath = "Prefabs/Cell";
        private GameObject cellPrefab;
        IGrid grid = new Domain.Grid();

        public void LoadPrefabs()
        {
            cellPrefab = Resources.Load<GameObject>(cellPath);
        }

        public void InitialGrid(int x, int y)
        {
            if (x < 3 || y < 3)
            {
                var errMask = "The minimum size of the grid should be 3 x 3. x = {0}, y = {1}";
                throw new ArgumentException(string.Format(errMask, x, y));
            }

            grid.Cells = new ICell[x][];

            for (int i = 0; i < x; i++)
            {
                grid.Cells[i] = new ICell[y];

                for (int j = 0; j < y; j++)
                {
                    var position = new Vector3(GameEngine.START_POINT.x + i,
                                               GameEngine.START_POINT.y + j,
                                               GameEngine.START_POINT.z + 0);
                    var instance = UnityEngine.Object.Instantiate(cellPrefab, position, Quaternion.identity);
                    grid.Cells[i][j] = instance.GetComponent(typeof(ICell)) as ICell;
                }
            }
        }

        public void FillingGrid(IPieceGenerator generator)
        {
            generator.GenerateGrid(grid);
        }

        public IGrid GetGridResult()
        {
            return grid;
        }
    }
}
