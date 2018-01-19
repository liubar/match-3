using UnityEngine;

namespace DomainLayer
{
    public class Piece
    {
        public Piece(GameObject pieceObj, Vector3 position)
        {
            Prefab = pieceObj;
            Object.Instantiate(pieceObj, position, pieceObj.transform.rotation);

            

        }

        public GameObject Prefab { get; private set; }
    }
}