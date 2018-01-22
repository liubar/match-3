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

        /// <summary>
        ///     Singleton instance
        /// </summary>
        public static GameContext Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new GameContext();

                return _instance;
            }
        }

        /// <summary>
        ///     Init GameContext
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="matchChecker"></param>
        /// <param name="pieceGenerator"></param>
        /// <param name="player"></param>
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
