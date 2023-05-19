using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _chooseLevelButton;
        [SerializeField] private Button _quitGameButton;
        [SerializeField] private GameObject _chooseLevelPanel;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(PlayGame);
            _chooseLevelButton.onClick.AddListener(ActivateChooseLevelPanel);
            _quitGameButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(PlayGame);
            _chooseLevelButton.onClick.RemoveListener(ActivateChooseLevelPanel);
            _quitGameButton.onClick.RemoveListener(QuitGame);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Levels"));
        }

        public void ActivateChooseLevelPanel()
        {
            _chooseLevelPanel.SetActive(true);
            gameObject.SetActive(false);

        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}