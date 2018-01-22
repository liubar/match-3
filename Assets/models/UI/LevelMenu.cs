using App;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelMenu : MonoBehaviour
    {
        public int gridWidth;
        public int gridHeigth;

        public void StartGame()
        {
            GameEngine.gridWidth = gridWidth;
            GameEngine.gridHeigth = gridHeigth;
            SceneManager.LoadScene(0);
        }
    }
}
