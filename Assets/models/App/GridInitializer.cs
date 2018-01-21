using Domain;

namespace App
{
    public class GridInitializer
    {
        private IGridBuilder _builder;
        private IPieceGenerator _generator;
        private IPieceProvider _pieceProvider;

        public GridInitializer(IGridBuilder builder, IPieceGenerator generator, IPieceProvider pieceProvider)
        {
            _builder = builder;
            _generator = generator;
            _pieceProvider = pieceProvider;
        }

        public void Build()
        {
            _builder.LoadPrefabs();
            _builder.InitialGrid(10, 10, _pieceProvider);
            _builder.FillingGrid(_generator);
            _builder.GenerateSpawnCells(_generator);
        }
    }
}
