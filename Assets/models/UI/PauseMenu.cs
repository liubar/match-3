using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                ResumeGame();
        }

        /// <summary>
        ///     Pause game
        /// </summary>
        public void PauseGame()
        {
            Time.timeScale = 0.0f;
        }

        /// <summary>
        ///     Resume game
        /// </summary>
        public void ResumeGame()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        /// <summary>
        ///     Exit
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}