namespace App
{
    public class GridInitializer
    {
        private IGridBuilder _builder;
        private IPieceGenerator _generator;
        private int _gridWidth;
        private int _gridHeigth;

        public GridInitializer(IGridBuilder builder, IPieceGenerator generator, int gridWidth, int gridHeigth)
        {
            _builder = builder;
            _generator = generator;
            _gridWidth = gridWidth;
            _gridHeigth = gridHeigth;
        }

        public void Build()
        {
            _builder.LoadPrefabs();
            _builder.InitialGrid(_gridWidth, _gridHeigth);
            //_builder.FillingGrid(_generator);
            _builder.GenerateSpawnCells(_generator);
        }
    }
}
