using UnityEngine;

namespace Domain
{
    public interface IPieceProvider
    {
        IGrid Grid { get; set; }
        void Move(ICell cell, Vector3 vector);
    }
}
