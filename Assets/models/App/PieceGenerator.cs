using Domain;
using UnityEngine;

namespace App
{
    public class PieceGenerator : IPieceGenerator
    {
        private string _prefabsPath = "Prefabs/Pieces/";
        private GameObject[] _piecesObjects;

        public PieceGenerator()
        {
            _piecesObjects = Resources.LoadAll<GameObject>(_prefabsPath);
        }

        public void GenerateGrid(IGrid grid)
        {
            for (int x = 0; x < grid.Cells.Length; x++)
            {
                for (int y = 0; y < grid.Cells.LongLength; y++)
                {
                    FillCell(grid.Cells[x][y]);
                }
            }
        }

        public void GeneratePiece(ICell cell)
        {
            FillCell(cell);
        }

        private void FillCell(ICell cell)
        {
            if (cell.Piece != null)
            {
                cell.Piece.Clear();
            }

            var position = ((MonoBehaviour)cell).GetComponent<Transform>().position;
            var instPiece = UnityEngine.Object.Instantiate(GetRandomPiece(), position, Quaternion.identity);
            cell.Piece = instPiece.GetComponent(typeof(IPiece)) as IPiece;
        }

        private GameObject GetRandomPiece()
        {
            var index = UnityEngine.Random.Range(0, _piecesObjects.Length);
            return _piecesObjects[index];
        }
    }
}
