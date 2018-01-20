using System;

namespace Domain
{
    public interface IPiece : IComparable<IPiece>
    {
        PieceType Type { get; set; }
        void Clear();
    }
}
