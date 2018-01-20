using Domain;

namespace App
{
    public interface IGridBuilder
    {
        void LoadPrefabs();
        void InitialGrid(int x, int y, IPieceProvider pieceProvider);
        void FillingGrid(IPieceGenerator generator);
        IGrid GetGridResult();
    }
}
