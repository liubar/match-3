using System;
using ModelsMatch3.interfaces;

namespace DomainLayer
{
    public class Grid : IGrid
    {
        private ICell[][] grid;

        public ICell[][] Cells
        {
            get { return grid; }
            set { grid = value; }
        }

        public void CheckMatch()
        {
            var a = "";



            var b = Cells[0][0];




        }

        public bool TrySwapCells(ICell cell1, ICell cell2)
        {
            throw new NotImplementedException();
        }
    }
}