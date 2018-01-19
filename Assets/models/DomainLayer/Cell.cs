using UnityEngine;

namespace DomainLayer
{
    public class Cell : MonoBehaviour
    {
        public CellState State = CellState.free;
        
        public void FillPiece()
        {
            Peice = new Piece(PieceService.GetRandomPiece(), gameObject.transform.position);
        }

        public Piece Peice { get; set; }
    }
}