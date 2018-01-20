using System;
using Domain;
using UnityEngine;

namespace App
{
    public class EasyGridBuilder : IGridBuilder
    {
        private string _cellPath = "Prefabs/Cell";
        private GameObject _cellPrefab;
        private IGrid _grid;

        public void LoadPrefabs()
        {
            _cellPrefab = Resources.Load<GameObject>(_cellPath);
        }

        public void InitialGrid(int x, int y, IPieceProvider pieceProvider)
        {
            _grid = new Domain.Grid();
            pieceProvider.Grid = _grid;

            if (x < 3 || y < 3)
            {
                var errMask = "The minimum size of the grid should be 3 x 3. x = {0}, y = {1}";
                throw new ArgumentException(string.Format(errMask, x, y));
            }

            _grid.Cells = new ICell[x][];

            for (int i = 0; i < x; i++)
            {
                _grid.Cells[i] = new ICell[y];

                for (int j = 0; j < y; j++)
                {
                    var position = new Vector3(GameEngine.START_POINT.x + i,
                                               GameEngine.START_POINT.y + j,
                                               GameEngine.START_POINT.z + 0);
                    var instance = UnityEngine.Object.Instantiate(_cellPrefab, position, Quaternion.identity);

                    _grid.Cells[i][j] = instance.GetComponent(typeof(ICell)) as ICell;
                    _grid.Cells[i][j].GridPosition = new GridPosition(i, j);
                    _grid.Cells[i][j].PieceProvider = pieceProvider;
                }
            }
        }

        public void FillingGrid(IPieceGenerator generator)
        {
            generator.GenerateGrid(_grid);
        }

        public IGrid GetGridResult()
        {
            return _grid;
        }
    }
}
