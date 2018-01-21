using Domain;

namespace App
{
    public interface IGridBuilder
    {
        void LoadPrefabs();
        void InitialGrid(int x, int y);
        void FillingGrid(IPieceGenerator generator);
        void GenerateSpawnCells(IPieceGenerator generator);
        IGrid GetGridResult();
    }
}
