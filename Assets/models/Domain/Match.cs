using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Match : IMatch
    {
        List<ICell> cells = new List<ICell>();

        public void AddCell(ICell cell)
        {
            cells.Add(cell);
        }

        public void AddRange(IEnumerable<ICell> range)
        {
            foreach (var cell in range)
            {
                if(cells.Contains(cell))
                    continue;

                cells.Add(cell);
            }
        }

        public bool Contains(ICell cell)
        {
            return cells.Contains(cell);
        }

        public bool AnyContains(IEnumerable<ICell> range)
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

        public int GetScore()
        {
            //1 piece = 100 scores
            return cells.Count * 100;
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cells.GetEnumerator();
        }
    }
}
