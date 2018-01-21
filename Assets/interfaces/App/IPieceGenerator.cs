using Domain;

namespace App
{
    public interface IPieceGenerator
    {
        void GenerateGrid(IGrid grid);
        void GeneratePiece(ICell gridCell);
    }
}
