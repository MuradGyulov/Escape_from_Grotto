using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class CanvasController : MonoBehaviour
{
    [Header("Texts on canvas")]
    [SerializeField] Text NumberOfCurrentScene;
    [Space(16)]
    [SerializeField] GameObject ControlButtonsPanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject LosePanel;

    private int sceneIndex;

    private void Start()
    {
        bool isTablet = YandexGame.EnvironmentData.isTablet;
        bool isMobile = YandexGame.EnvironmentData.isMobile;
        bool isDesktop = YandexGame.EnvironmentData.isDesktop;

        if (isTablet || isMobile)
        {
            ControlButtonsPanel.SetActive(true);
        }
        else { ControlButtonsPanel.SetActive(false); }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        NumberOfCurrentScene.text = "Level:" + sceneIndex.ToString();

        Player.SendPlayerDead.AddListener(LoseDelay);
        Player.SendPlayerWin.AddListener(PlayerWin);
    }

        private void LoseDelay()
        {
            Invoke("PlayerLose", 2f);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(sceneIndex);
            Time.timeScale = 1;
        }

        public void CounntinueGame()
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }


        public void LoadNextLevel()
        {
            SceneManager.LoadScene(sceneIndex + 1);
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }

        private void PlayerLose()
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void PlayerWin()
        {
            WinPanel.SetActive(true);
        }
    
}
