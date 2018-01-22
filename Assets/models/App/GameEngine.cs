using System.Collections;
using Domain;
using UnityEngine;

namespace App
{
    public class GameEngine : MonoBehaviour
    {
        public static Vector3 START_POINT = new Vector3(0, 0, 0);
        public int gridWidth = 10;
        public int gridHeigth = 10;
        public Player player;
        //private LevelManager levelManager;
        private IBoard _board;
        private IPieceGenerator _generator;
        private IMatchChecker _matchChecker;

        private WaitForSeconds _waitingTime = new WaitForSeconds(0.3f);
        private bool _isWork = false;

        void Awake()
        {
            player = new Player("User", 0, 0);
            //levelManager = new LevelManager();
        }

        /// <summary>
        ///     Initialize grid and state machine
        /// </summary>
        void Start()
        {
            IGridBuilder builder = new EasyGridBuilder();
            _generator = new PieceGenerator();
            _matchChecker = new MatchChecker();

            var initializer = new GridInitializer(builder, _generator, gridWidth, gridHeigth);
            initializer.Build();
            var grid = builder.GetGridResult();
            _board = new BoardDefault(grid);

            GameContext.Instance.Initialize(grid, _matchChecker, _generator, player);
            GameContext.Instance.Handle();
        }

        /// <summary>
        ///     basic logic of the game
        ///     implemented using a finite state machine
        /// </summary>
        /// <returns>_waitingTime</returns>
        IEnumerator Handle()
        {
            _isWork = true;
            while (true)
            {
                if (GameContext.Instance.State is SwapState ||
                    GameContext.Instance.State is UndoSwapState)
                {
                    GameContext.Instance.Handle();
                    break;
                }
                
                yield return _waitingTime;
                GameContext.Instance.Handle();
            }

            _isWork = false;
        }

        void Update()
        {
            if(!_isWork)
                StartCoroutine(Handle());
        }
    }
}
