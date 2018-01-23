using System.Collections;
using Domain;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace App
{
    public class GameEngine : MonoBehaviour
    {
        public static Vector3 START_POINT = new Vector3(0, 0, 0);
        public static int gridWidth = 10;
        public static int gridHeigth = 10;

        public Player player;

        private IPieceGenerator _generator;
        private IMatchChecker _matchChecker;

        private WaitForSeconds _waitingTime = new WaitForSeconds(0.1f);
        private bool _isWork;
        private string _scoreTag = "Score";
        private string _pauseMenuTag = "PauseMenu";
        private GameObject _pauseMenu;

        void Awake()
        {
            player = new Player("User", 0);

            // Init Score
            var scoreObj = GameObject.FindGameObjectWithTag(_scoreTag).GetComponent<Text>();
            player.updateScore += score => scoreObj.text = string.Format("Score: {0}", score);

            _pauseMenu = GameObject.FindGameObjectWithTag(_pauseMenuTag);
            _pauseMenu.SetActive(false);
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
            var board = new BoardDefault(grid);
            
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
            if(Input.GetKeyUp(KeyCode.Escape))
                Pause();

            if(!_isWork)
                StartCoroutine(Handle());
        }

        void Pause()
        {
            _pauseMenu.SetActive(true);
            _pauseMenu.gameObject.GetComponent<PauseMenu>().PauseGame();
        }
    }
}
