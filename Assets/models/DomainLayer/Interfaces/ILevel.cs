using InfrastructureLayer;
using UnityEngine.UI;

namespace DomainLayer
{
    public interface ILevel
    {
        int Number { get; }
        Image TitleImg { get; }
        IBoard Board { get; }
        Timer Timer { get; }
    }
}