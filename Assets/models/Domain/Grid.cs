namespace Domain
{
    public class Grid : IGrid
    {
        private IGridCell[][] _grid;

        public IGridCell[][] GridCells
        {
            get { return _grid; }
            set { _grid = value; }
        }

        /// <summary>
        ///     Checks the fullness of all grid cells
        /// </summary>
        public bool IsFull
        {
            get
            {
                foreach (var cells in _grid)
                {
                    foreach (var cell in cells)
                    {
                        if (cell.IsEmpty)
                            return false;
                    }
                }

                return true;
            }
        }
    }
}