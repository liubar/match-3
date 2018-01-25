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
        public static int gridWidth = 3;
        public static int gridHeigth = 3;
        public Player player;

        private IPieceGenerator _generator;
        private IMatchChecker _matchChecker;

        private WaitForSeconds _waitingTime = new WaitForSeconds(0.2f);
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

            // Init Pause Menu
            _pauseMenu = GameObject.FindGameObjectWithTag(_pauseMenuTag);
            _pauseMenu.SetActive(false);
        }

        /// <summary>
        ///     Initialize grid and state machine
        /// </summary>
        void Start()
        {
#if UNITY_STANDALONE

            IMoveController moveController = new ClickMoveController();
#endif

#if UNITY_ANDROID
            IMoveController moveController = new TouchMoveController();
#endif

            IGridBuilder builder = new EasyGridBuilder();
            _generator = new PieceGenerator();
            _matchChecker = new MatchChecker();

            var initializer = new GridInitializer(builder, _generator, gridWidth, gridHeigth);
            initializer.Build();
            var grid = builder.GetGridResult();
            new BoardDefault(grid);

            GameContext.Instance.Initialize(grid, _matchChecker, _generator, player, moveController);
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
                // States operating without delay
                if (GameContext.Instance.State is SwapState ||
                    GameContext.Instance.State is UndoSwapState ||
                    GameContext.Instance.State is WaitingState)
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

        /// <summary>
        ///     Pause game and run pause menu
        /// </summary>
        void Pause()
        {
            _pauseMenu.SetActive(true);
            _pauseMenu.gameObject.GetComponent<PauseMenu>().PauseGame();
        }
    }
}
