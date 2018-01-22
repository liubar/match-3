namespace Domain
{
    public interface IGridCell : ICell
    {
        IGridPosition GridPosition { get; set; }
        CellState CellState { get; set; }
        bool IsEmpty { get; }
        bool ContainsPiece(IGridCell piece);
    }
}
