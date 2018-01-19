using UnityEngine;

namespace DomainLayer
{
    public class PieceService
    {
        public static GameObject[] PiecesObjects;
        
        public static GameObject GetRandomPiece()
        {
            var index = Random.Range(0, PiecesObjects.Length);
            return PiecesObjects[index];
        }
    }
}