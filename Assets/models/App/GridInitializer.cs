namespace App
{
    public class GridInitializer
    {
        private IGridBuilder _builder;
        private IPieceGenerator _generator;

        public GridInitializer(IGridBuilder builder, IPieceGenerator generator)
        {
            _builder = builder;
            _generator = generator;
        }

        public void Build()
        {
            _builder.LoadPrefabs();
            _builder.InitialGrid(10, 10);
            _builder.FillingGrid(_generator);
        }
    }
}
