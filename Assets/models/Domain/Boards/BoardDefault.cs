using App;

namespace Domain
{
    class BoardDefault : IBoard
    {
        IGrid _grid;
        
        IGrid IBoard.grid { get { return _grid; }}

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="grid"></param>
        public BoardDefault(IGrid grid)
        {
            _grid = grid;
        }
    }
}
