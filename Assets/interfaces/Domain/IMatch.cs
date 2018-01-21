using System.Collections.Generic;

namespace Domain
{
    public interface IMatch : IEnumerable<IGridCell>
    {
        void AddCell(IGridCell gridCell);
        void AddRange(IEnumerable<IGridCell> range);
        bool Contains(IGridCell gridCell);
        bool AnyContains(IEnumerable<IGridCell> range);
        List<IGridCell> GetCells();
        int GetScore();
    }
}
