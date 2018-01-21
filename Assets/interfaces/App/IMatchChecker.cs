using System.Collections.Generic;
using Domain;

namespace App
{
    public interface IMatchChecker
    {
        IEnumerable<IMatch> CheckMatch(IGrid grid);
        bool CheckChanceMacth(IGrid grid);
        bool CellContainsMatch(IGrid grid, IGridCell cell);
    }
}
