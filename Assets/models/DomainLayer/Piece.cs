using ModelsMatch3;
using UnityEngine;

namespace DomainLayer
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

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
        
        //void OnMouseDown()
        //{
        //    Destroy(this.gameObject);
        //}
    }
}