using Domain;
using UnityEngine;

namespace App
{
    public class PieceGenerator : IPieceGenerator
    {
        private string _prefabsPath = "Prefabs/Pieces/";
        private readonly GameObject[] _piecesObjects;

        /// <summary>
        ///     ctor. Load all prefabs on the folder path "Prefabs/Pieces/"
        /// </summary>
        public PieceGenerator()
        {
            _piecesObjects = Resources.LoadAll<GameObject>(_prefabsPath);
        }

        /// <summary>
        ///     Clears and fills all cells in the grid
        /// </summary>
        /// <param name="grid">Upgradable grid</param>
        public void GenerateGrid(IGrid grid)
        {
            for (int x = 0; x < grid.GridCells.Length; x++)
            {
                for (int y = 0; y < grid.GridCells.LongLength; y++)
                {
                    FillCell(grid.GridCells[x][y]);
                }
            }
        }

        /// <summary>
        ///     Fills the cell with a chip
        /// </summary>
        /// <param name="gridCell">Upgradable cell</param>
        public void GeneratePiece(ICell gridCell)
        {
            FillCell(gridCell);
        }

        /// <summary>
        ///     Fills the cell with a chip
        /// </summary>
        /// <param name="gridCell">Upgradable cell</param>
        private void FillCell(ICell gridCell)
        {
            if (gridCell.Piece != null)
            {
                gridCell.Piece.Clear();
            }

            var position = ((MonoBehaviour)gridCell).GetComponent<Transform>().position;
            Object.Instantiate(GetRandomPiece(), position, Quaternion.identity);
        }

        /// <summary>
        ///     Finds a random chip from the prefab list
        /// </summary>
        /// <returns>Random piece prefab</returns>
        private GameObject GetRandomPiece()
        {
            var index = Random.Range(0, _piecesObjects.Length);
            return _piecesObjects[index];
        }
    }
}
