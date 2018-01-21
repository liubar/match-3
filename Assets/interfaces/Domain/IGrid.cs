namespace Domain
{
    public interface IGrid
    {
        IGridCell[][] GridCells { get; set; }

        bool TrySwapCells(IGridCell cell1, IGridCell cell2);
        void CheckMatch();
    }
}
