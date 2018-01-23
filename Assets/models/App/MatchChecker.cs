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
            var findingMatchs = FindMatches(grid);
            
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
            return CheckVerticallyChanceMacth(grid) ||
                   CheckHorizontallyChanceMacth(grid) ||
                   CheckChanceMacthFromSides(grid);
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
        ///     Finding all matches
        /// </summary>
        /// <param name="grid">Verifiable mesh</param>
        /// <returns>All cells participating in matches</returns>
        private List<IGridCell[]> FindMatches(IGrid grid)
        {
            var arr = grid.GridCells;
            var result = new List<IGridCell[]>();

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.LongLength; y++)
                {
                    var currentCell = arr[x][y];

                    // Check from top
                    if (y + 2 < arr.LongLength)
                    {
                        var f = arr[x][y + 1];
                        var s = arr[x][y + 2];

                        if (CellComparer(currentCell, f,s))
                        {
                            result.Add(new[] { currentCell, f, s });
                        }
                    }

                    // Check from bot
                    if (y - 2 >= 0)
                    {
                        var f = arr[x][y - 1];
                        var s = arr[x][y - 2];

                        if (CellComparer(currentCell, f, s))
                        {
                            result.Add(new[] { currentCell, f, s });
                        }
                    }


                    // Check from left
                    if (x - 2 >= 0)
                    {
                        var f = arr[x - 1][y];
                        var s = arr[x - 2][y];

                        if (CellComparer(currentCell, f, s))
                        {
                            result.Add(new[] { currentCell, f, s });
                        }
                    }

                    // Check from right
                    if (x + 2 < arr.Length)
                    {
                        var f = arr[x + 1][y];
                        var s = arr[x + 2][y];

                        if (CellComparer(currentCell, f, s))
                        {
                            result.Add(new[] { currentCell, f, s });
                        }
                    }
                }
            }

            return result;
        }
        
        private bool CellComparer(IGridCell first, IGridCell second, IGridCell third)
        {
            return first.ContainsPiece(second) && first.ContainsPiece(third);
        }

        /// <summary>
        ///     Check Chance Macth from horizontal lines
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private bool CheckHorizontallyChanceMacth(IGrid grid)
        {
            var arr = grid.GridCells;

            for (int y = 0; y < arr.LongLength; y++)
            {
                for (int x = 0; x < arr.Length; x++)
                {
                    var currentEl = arr[x][y];

                    // Check from right
                    if (x + 3 <= arr.Length - 1)
                    {
                        var f = arr[x + 2][y];
                        var s = arr[x + 3][y];

                        if (CellComparer(currentEl, f, s))
                            return true;
                    }

                    // Chech from left
                    if (x - 3 >= 0)
                    {
                        var f = arr[x - 2][y];
                        var s = arr[x - 3][y];

                        if (CellComparer(currentEl, f, s))
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Check Chance Macth from vertical lines
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private bool CheckVerticallyChanceMacth(IGrid grid)
        {
            var arr = grid.GridCells;

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.LongLength; y++)
                {
                    var currentEl = arr[x][y];

                    // Check from top
                    if (y + 3 <= arr.LongLength - 1)
                    {
                        var f = arr[x][y + 2];
                        var s = arr[x][y + 3];

                        if (CellComparer(currentEl, f, s))
                            return true;
                    }

                    // Check from bot
                    if (y - 3 >= 0)
                    {
                        var f = arr[x][y - 2];
                        var s = arr[x][y - 3];

                        if (CellComparer(currentEl, f, s))
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Check Chance Macth from sides
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private bool CheckChanceMacthFromSides(IGrid grid)
        {
            var arr = grid.GridCells;

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.LongLength; y++)
                {
                    /*   leftTop |    -    | rightTop
                            -    |  center |    -
                         leftBot |    -    | rightBot
                    */
                    var center = arr[x][y];
                    //var comparer = new Func<IGridCell, IGridCell, bool>((f, s) => center.ContainsPiece(f) && center.ContainsPiece(s));

                    // Check Bot
                    if (x != 0 && x != arr.Length - 1 && y != 0)
                    {
                        var leftBot = arr[x - 1][y - 1];
                        var rightBot = arr[x + 1][y - 1];
                        var left = arr[x - 1][y];
                        var right = arr[x + 1][y];

                        if (CellComparer(center, leftBot, rightBot) || CellComparer(center, left, rightBot) || CellComparer(center, right, leftBot))
                            return true;
                    }

                    // Check Right
                    if (x != arr.Length - 1 && y != 0 && y != arr.LongLength - 1)
                    {
                        var rightTop = arr[x + 1][y + 1];
                        var rightBot = arr[x + 1][y - 1];
                        var top = arr[x][y + 1];
                        var bot = arr[x][y - 1];

                        if (CellComparer(center, rightTop, rightBot) || CellComparer(center, top, rightBot) || CellComparer(center, bot, rightTop))
                            return true;
                    }

                    // Check Top
                    if (x != 0 && x != arr.Length - 1 && y != arr.LongLength - 1)
                    {
                        var leftTop = arr[x - 1][y + 1];
                        var rightTop = arr[x + 1][y + 1];
                        var left = arr[x - 1][y];
                        var right = arr[x + 1][y];
                        
                        if (CellComparer(center, leftTop, rightTop) || CellComparer(center, left, rightTop) || CellComparer(center, right, leftTop))
                            return true;
                    }

                    // Check Left
                    if (x != 0 && y != 0 && y != arr.LongLength - 1)
                    {
                        var leftTop = arr[x - 1][y + 1];
                        var leftBot = arr[x - 1][y - 1];
                        var top = arr[x][y + 1];
                        var bot = arr[x][y - 1];

                        if (CellComparer(center, leftTop, leftBot) || CellComparer(center, top, leftBot) || CellComparer(center, bot, leftTop))
                            return true;
                    }
                }
            }

            return false;
        }

    }
}
