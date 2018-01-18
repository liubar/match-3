using UnityEngine;

namespace DomainLayer
{
    public class Grid : MonoBehaviour
    {
        public Grid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}