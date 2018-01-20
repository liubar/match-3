using System;

namespace Domain
{
    public interface IPiece : IEquatable<IPiece>
    {
        PieceType Type { get; }
        void Clear();
    }
}
