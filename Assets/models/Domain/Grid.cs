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

        public bool IsFull
        {
            get
            {
                foreach (var cells in _grid)
                {
                    foreach (var cell in cells)
                    {
                        if (cell.Piece == null)
                            return false;
                    }
                }

                return true;
            }
        }
    }
}