using Domain;
using UnityEngine;

namespace App
{
    public class GameEngine : MonoBehaviour
    {
        public static readonly Vector3 START_POINT = new Vector3(0, 0, 0);

        private LevelManager levelManager;
        private IBoard board;

        void Awake()
        {
            levelManager = new LevelManager();
        }

        // Use this for initialization
        void Start()
        {
            IGridBuilder builder = new EasyGridBuilder();
            var generator = new PieceGenerator();
            var initializer = new GridInitializer(builder, generator);
            initializer.Build();

            board = new BoardDefault(builder.GetGridResult());


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
