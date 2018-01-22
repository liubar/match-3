using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Match : IMatch
    {
        List<IGridCell> _cells = new List<IGridCell>();

        /// <summary>
        ///     Add cell in match
        /// </summary>
        /// <param name="gridCell">Adding cell</param>
        public void AddCell(IGridCell gridCell)
        {
            _cells.Add(gridCell);
        }

        /// <summary>
        ///     Adding a cell array in match
        /// </summary>
        /// <param name="range">Adding array</param>
        public void AddRange(IEnumerable<IGridCell> range)
        {
            foreach (var cell in range)
            {
                if(_cells.Contains(cell))
                    continue;

                _cells.Add(cell);
            }
        }

        /// <summary>
        ///     Check the participation of the cell in the match
        /// </summary>
        /// <param name="gridCell">Verifiable cell</param>
        /// <returns>true == 'The cell participates in the match'</returns>
        public bool Contains(IGridCell gridCell)
        {
            return _cells.Contains(gridCell);
        }

        /// <summary>
        ///     Check the participation of any element in the match
        /// </summary>
        /// <param name="range">Verifiable array</param>
        /// <returns>true == 'The any cell participates in the match'</returns>
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

        /// <summary>
        ///     Counts and returns all points for matches
        /// </summary>
        /// <returns>Score</returns>
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
