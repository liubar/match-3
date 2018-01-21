using Domain;

namespace App
{
    public interface ISpawnCell : ICell
    {
        IGridCell UpperCell { get; set; }
        IPieceGenerator PieceGenerator { get; set; }
    }
}
