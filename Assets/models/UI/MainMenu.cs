using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("LevelScene");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}