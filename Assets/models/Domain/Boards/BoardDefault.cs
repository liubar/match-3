using App;

namespace Domain
{
    class BoardDefault : IBoard
    {
        IGrid _grid;
        
        IGrid IBoard.grid { get { return _grid; }}

        public BoardDefault(IGrid grid)
        {
            _grid = grid;
        }
    }
}
