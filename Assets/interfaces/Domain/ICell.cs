using System;

namespace Domain
{
    public interface ICell
    {
        IGridPosition GridPosition { get; set; }
        IPiece Piece { get; set; }
        CellState CellState { get; set; }
        IPieceProvider PieceProvider { get; set; }
        bool ContainsPiece(ICell piece);
    }
}
