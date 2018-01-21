namespace Domain
{
    public interface IGrid
    {
        IGridCell[][] GridCells { get; set; }
        bool IsFull { get; }
    }
}
