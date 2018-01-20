using System.Collections.Generic;

namespace Domain
{
    public interface IMatch : IEnumerable<IPiece>
    {
        int GetScore();
    }
}
