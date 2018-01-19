namespace DomainLayer
{
    class BoardDefault : IBoard
    {
        Grid grid = new Grid(10, 10);
        
        public Grid Grid
        {
            get { return grid; }
        }
    }
}
