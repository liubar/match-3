using App;

namespace Domain
{
    public class GameContext
    {
        public IGrid grid;
        public IMatchChecker matchChecker;
        public IPieceGenerator pieceGenerator;
        public Player player;

        private static GameContext _instance;

        public StateGame State { get; set; }

        private GameContext()
        {
            State = new GenerationGridState();
        }

        public static GameContext Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new GameContext();

                return _instance;
            }
        }

        public void Initialize(IGrid grid, IMatchChecker matchChecker, IPieceGenerator pieceGenerator, Player player)
        {
            this.grid = grid;
            this.matchChecker = matchChecker;
            this.pieceGenerator = pieceGenerator;
            this.player = player;
        }

        public void Handle(object[] additionalParams = null)
        {
            this.State.HandleState(this, additionalParams);
        }
    }
}
