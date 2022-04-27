using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class PauseMenu : MonoBehaviour
    {

        public bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}
