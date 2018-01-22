using System.Collections.Generic;
using Domain;

namespace App
{
    public class MatchChecker : IMatchChecker
    {
        /// <summary>
        ///     Check the entire grid on match
        /// </summary>
        /// <param name="grid">Verifiable mesh</param>
        /// <returns>All found matchs</returns>
        public IEnumerable<IMatch> CheckMatch(IGrid grid)
        {
            var result = new List<Match>();
            var findingMatchs = CheckRows(grid);
            findingMatchs.AddRange(CheckColumns(grid));

            foreach (var par in findingMatchs)
            {
                var isAdding = false;

                result.ForEach(el =>
                {
                    if (el.AnyContains(par))
                    {
                        el.AddRange(par);
                        isAdding = true;
                    }
                });

                if (!isAdding)
                {
                    var match = new Match();
                    match.AddRange(par);
                    result.Add(match);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        ///     Check on the possibility of a match with any course
        /// 
        ///     Check 'c' equals '*'
        ///        * - *      * - -       - - -       - - *
        ///        - c -      - c -       - c -       - c -
        ///        - - -      * - -       * - *       - - *
        /// 
        /// </summary>
        /// <param name="grid">Verifiable mesh</param>
        /// <returns>true == Match possible</returns>
        public bool CheckChanceMacth(IGrid grid)
        {
            var arr = grid.GridCells;

            for (int x = 1; x < arr.Length - 1; x++)
            {
                for (int y = 1; y < arr.LongLength - 1; y++)
                {
                    var c = arr[x][y];

                    if (c.ContainsPiece(arr[x - 1][y - 1]) && c.ContainsPiece(arr[x - 1][y + 1]) ||
                        c.ContainsPiece(arr[x + 1][y - 1]) && c.ContainsPiece(arr[x + 1][y - 1]) ||
                        c.ContainsPiece(arr[x + 1][y - 1]) && c.ContainsPiece(arr[x + 1][y + 1]) ||
                        c.ContainsPiece(arr[x - 1][y + 1]) && c.ContainsPiece(arr[x + 1][y + 1]) )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Check the participation of the cell in the match
        /// </summary>
        /// <param name="grid">The grid in which the checking cell is located</param>
        /// <param name="cell">checking cell</param>
        /// <returns>true == 'the cell participates in the match'</returns>
        public bool CellContainsMatch(IGrid grid, IGridCell cell)
        {
            var matchs = CheckMatch(grid);

            foreach (var match in matchs)
            {
                if (match.Contains(cell))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Finding all vertical matches
        /// </summary>
        /// <param name="grid">Verifiable mesh</param>
        /// <returns>All cells participating in vertical matches</returns>
        List<IGridCell[]> CheckColumns(IGrid grid)
        {
            var arr = grid.GridCells;
            var result = new List<IGridCell[]>();

            for (int y = 0; y < arr.Length; y++)
            {
                for (int x = 0; x < arr.LongLength - 2; x++)
                {
                    if (arr[x][y].ContainsPiece(arr[x + 1][y]) && arr[x][y].ContainsPiece(arr[x + 2][y]))
                    {
                        result.Add(new[] { arr[x][y], arr[x + 1][y], arr[x + 2][y] });
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Finding all horizontal matches
        /// </summary>
        /// <param name="grid">Verifiable mesh</param>
        /// <returns>All cells participating in horizontal matches</returns>
        List<IGridCell[]> CheckRows(IGrid grid)
        {
            var arr = grid.GridCells;
            var result = new List<IGridCell[]>();

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.LongLength - 2; y++)
                {
                    if (arr[x][y].ContainsPiece(arr[x][y + 1]) && arr[x][y].ContainsPiece(arr[x][y + 2]))
                    {
                        result.Add(new[] { arr[x][y], arr[x][y + 1], arr[x][y + 2] });
                    }
                }
            }

            return result;
        }
    }
}
