namespace App
{
    public class GridInitializer
    {
        private IGridBuilder _builder;
        private IPieceGenerator _generator;
        private int _gridWidth;
        private int _gridHeigth;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="generator"></param>
        /// <param name="gridWidth"></param>
        /// <param name="gridHeigth"></param>
        public GridInitializer(IGridBuilder builder, IPieceGenerator generator, int gridWidth, int gridHeigth)
        {
            _builder = builder;
            _generator = generator;
            _gridWidth = gridWidth;
            _gridHeigth = gridHeigth;
        }

        /// <summary>
        ///     Build and filling all cells (grid cells, spawn cells)
        /// </summary>
        public void Build()
        {
            _builder.LoadPrefabs();
            _builder.InitialGrid(_gridWidth, _gridHeigth);
            //_builder.FillingGrid(_generator);
            _builder.GenerateSpawnCells(_generator);
        }
    }
}
