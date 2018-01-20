namespace Domain
{
    public interface IGrid
    {
        ICell[][] Cells { get; set; }

        bool TrySwapCells(ICell cell1, ICell cell2);
        void CheckMatch();
    }
}
