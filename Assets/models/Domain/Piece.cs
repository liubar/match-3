using UnityEngine;

namespace Domain
{
    public class Piece : MonoBehaviour, IPiece
    {
        public PieceType type;

        public PieceType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int CompareTo(IPiece other)
        {
            return Type.CompareTo(other.Type);
        }

        public void Clear()
        {
            Destroy(this.gameObject);
        }
    }
}