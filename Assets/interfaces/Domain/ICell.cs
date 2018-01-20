using System;

namespace Domain
{
    public interface ICell
    {
        IPiece Piece { get; set; }
        CellState CellState { get; set; }
        bool ContainsPiece(ICell piece);
    }
}
