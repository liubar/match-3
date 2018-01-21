using UnityEngine;

namespace Domain
{
    public interface IPieceProvider
    {
        IGrid Grid { get; set; }
        void Move(IGridCell gridCell, Vector3 vector);
        void DeletePiece(IGridCell gridCell);
    }
}
