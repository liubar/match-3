using Domain;
using UnityEngine;

namespace App
{
    public class PieceGenerator : IPieceGenerator
    {
        private string _prefabsPath = "Prefabs/Pieces/";
        private readonly GameObject[] _piecesObjects;

        public PieceGenerator()
        {
            _piecesObjects = Resources.LoadAll<GameObject>(_prefabsPath);
        }

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

        public void GeneratePiece(ICell gridCell)
        {
            FillCell(gridCell);
        }

        private void FillCell(ICell gridCell)
        {
            if (gridCell.Piece != null)
            {
                gridCell.Piece.Clear();
            }

            var position = ((MonoBehaviour)gridCell).GetComponent<Transform>().position;
            Object.Instantiate(GetRandomPiece(), position, Quaternion.identity);
        }

        private GameObject GetRandomPiece()
        {
            var index = Random.Range(0, _piecesObjects.Length);
            return _piecesObjects[index];
        }
    }
}
