namespace Domain
{
    public interface IGridCell : ICell
    {
        IGridPosition GridPosition { get; set; }
        CellState CellState { get; set; }
        IPieceProvider PieceProvider { get; set; }
        bool ContainsPiece(IGridCell piece);
    }
}
