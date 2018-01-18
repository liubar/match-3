using UnityEngine.UI;

namespace DomainLayer
{
    public class Level_1_1 : ILevel
    {
        public Level_1_1()
        {
            Board = new BoardDefault();
        }

        public int Number
        {
            get { return 1; }
        }

        public Image TitleImg { get; set; }

        public IBoard Board { get; private set; }
    }
}
