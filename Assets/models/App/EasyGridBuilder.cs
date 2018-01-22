using System;
using System.Linq;
using Domain;
using UnityEngine;

namespace App
{
    public class EasyGridBuilder : IGridBuilder
    {
        private string _cellPath = "Prefabs/Cell";
        private string _spawnCellPath = "Prefabs/SpawnCell";
        private string _platformTag = "Platform";
        private string _mainCameraTag = "MainCamera";
        private GameObject _cellPrefab;
        private GameObject _spawnCellPrefab;
        private IGrid _grid;

        /// <summary>
        ///     Initialize cell and spawnCell prefabs
        /// </summary>
        public void LoadPrefabs()
        {
            _cellPrefab = Resources.Load<GameObject>(_cellPath);
            _spawnCellPrefab = Resources.Load<GameObject>(_spawnCellPath);
        }

        /// <summary>
        ///     Change size platform
        /// </summary>
        /// <param name="widthLine">count pieces in line</param>
        public void InitialPlatform(int widthLine)
        {
            var platform = GameObject.FindGameObjectsWithTag(_platformTag).First();
            var pos = platform.transform.position;
            var scale = platform.transform.localScale;

            // 0.5f -> half Piece size
            var newPosition = new Vector3(((float)widthLine / 2) - 0.5f, pos.y, pos.z);
            var newScale = new Vector3(widthLine + 2, scale.y, scale.z);

            platform.transform.position = newPosition;
            platform.transform.localScale = newScale;
        }

        /// <summary>
        ///     Change position main camera
        /// </summary>
        /// <param name="widthLine">count pieces in line</param>
        public void InitializeCameraPosition(int widthLine)
        {
            var camera = GameObject.FindGameObjectsWithTag(_mainCameraTag).First();
            var newPosition = new Vector3(((float)widthLine / 2) - 0.5f, (float)widthLine / 2, (widthLine + 4) * -1);
            camera.transform.position = newPosition;
        }

        /// <summary>
        ///     Creating and filling all grid cells
        /// </summary>
        /// <param name="x">grid width</param>
        /// <param name="y">grid heigth</param>
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

        /// <summary>
        ///     Filling all cells
        /// </summary>
        /// <param name="generator"></param>
        public void FillingGrid(IPieceGenerator generator)
        {
            generator.GenerateGrid(_grid);
        }

        /// <summary>
        ///     Generate all spawn cells
        /// </summary>
        /// <param name="generator"></param>
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
