using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Match : IMatch
    {
        List<IGridCell> _cells = new List<IGridCell>();

        public void AddCell(IGridCell gridCell)
        {
            _cells.Add(gridCell);
        }

        public void AddRange(IEnumerable<IGridCell> range)
        {
            foreach (var cell in range)
            {
                if(_cells.Contains(cell))
                    continue;

                _cells.Add(cell);
            }
        }

        public bool Contains(IGridCell gridCell)
        {
            return _cells.Contains(gridCell);
        }

        public bool AnyContains(IEnumerable<IGridCell> range)
        {
            foreach (var cell in range)
            {
                if (Contains(cell))
                {
                    return true;
                }
            }

            return false;
        }

        public List<IGridCell> GetCells()
        {
            return _cells;
        }

        public int GetScore()
        {
            //1 piece = 100 scores
            return _cells.Count * 100;
        }

        public IEnumerator<IGridCell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
