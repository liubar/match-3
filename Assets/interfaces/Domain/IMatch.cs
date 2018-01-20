using System.Collections.Generic;

namespace Domain
{
    public interface IMatch : IEnumerable<ICell>
    {
        void AddCell(ICell cell);
        void AddRange(IEnumerable<ICell> range);
        bool Contains(ICell cell);
        bool AnyContains(IEnumerable<ICell> range);
        int GetScore();
    }
}
