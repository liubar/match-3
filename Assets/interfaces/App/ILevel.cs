using Infrastructure;

namespace App
{
    public interface ILevel
    {
        int Number { get; }
        //Image TitleImg { get; }
        IBoard Board { get; }
        ITimer Timer { get; }
    }
}
