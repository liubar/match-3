using System;

namespace Domain
{
    public interface ICell : IComparable<ICell>
    {
        IPiece Piece { get; set; }
        CellState CellState { get; set; }
    }
}
