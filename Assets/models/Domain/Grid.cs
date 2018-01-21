using System;

namespace Domain
{
    public class Grid : IGrid
    {
        private IGridCell[][] grid;

        public IGridCell[][] GridCells
        {
            get { return grid; }
            set { grid = value; }
        }

        public void CheckMatch()
        {
            var a = "";



            var b = GridCells[0][0];




        }

        public bool TrySwapCells(IGridCell cell1, IGridCell cell2)
        {
            throw new NotImplementedException();
        }
    }

     

    

    

}