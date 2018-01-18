using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer
{
    class BoardDefault : IBoard
    {
        public Grid Grid
        {
            get
            {
                return new Grid(10, 10);
            }
        }
    }
}
