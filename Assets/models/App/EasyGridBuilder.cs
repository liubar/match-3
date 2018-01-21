using System;
using Domain;
using UnityEngine;

namespace App
{
    public class EasyGridBuilder : IGridBuilder
    {
        private string _cellPath = "Prefabs/Cell";
        private string _spawnCellPath = "Prefabs/SpawnCell";
        private GameObject _cellPrefab;
        private GameObject _spawnCellPrefab;
        private IGrid _grid;

        public void LoadPrefabs()
        {
            _cellPrefab = Resources.Load<GameObject>(_cellPath);
            _spawnCellPrefab = Resources.Load<GameObject>(_spawnCellPath);
        }

        public void InitialGrid(int x, int y)
        {
            _grid = new Domain.Grid();

            if (x < 3 || y < 3)
            {
                var errMask = "The minimum size of the grid should be 3 x 3. x = {0}, y = {1}";
                throw new ArgumentException(string.Format(errMask, x, y));
            }

            _grid.GridCells = new IGridCell[x][];

            for (int i = 0; i < x; i++)
            {
                _grid.GridCells[i] = new IGridCell[y];

                for (int j = 0; j < y; j++)
                {
                    var position = new Vector3(GameEngine.START_POINT.x + i,
                                               GameEngine.START_POINT.y + j,
                                               GameEngine.START_POINT.z + 0);
                    var instance = UnityEngine.Object.Instantiate(_cellPrefab, position, Quaternion.identity);
                    
                    _grid.GridCells[i][j] = instance.GetComponent(typeof(IGridCell)) as IGridCell;
                    _grid.GridCells[i][j].GridPosition = new GridPosition(i, j);
                }
            }
        }

        public void FillingGrid(IPieceGenerator generator)
        {
            generator.GenerateGrid(_grid);
        }

        public void GenerateSpawnCells(IPieceGenerator generator)
        {
            for (int i = 0; i < _grid.GridCells.Length; i++)
            {
                var pos = new Vector3(GameEngine.START_POINT.x + i,
                    GameEngine.START_POINT.y + _grid.GridCells.LongLength,
                    GameEngine.START_POINT.z + 0);
                var spawnInstantiate = UnityEngine.Object.Instantiate(_spawnCellPrefab, pos, Quaternion.identity);
                var spawnCell = spawnInstantiate.GetComponent(typeof(ISpawnCell)) as ISpawnCell;
                spawnCell.UpperCell = _grid.GridCells[i][_grid.GridCells.LongLength - 1];
                spawnCell.PieceGenerator = generator;
            }
        }

        public IGrid GetGridResult()
        {
            return _grid;
        }
    }
}
