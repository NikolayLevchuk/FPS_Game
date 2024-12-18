using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MenusPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _level;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private LevelControl _levelControl;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button[] _mainMenuButtons;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(ToNextLevel);
            _playAgainButton.onClick.AddListener(PlayeAgain);
            foreach(Button button in _mainMenuButtons)
            {
                button.onClick.AddListener(ToMainMenu);
            }
        }

        private void Start()
        {
            _levelControl.LevelDone += ShowWinPanel;
            _levelControl.LevelFailed += ShowLosePanel;
        }

        public void ShowWinPanel()
        {
            _levelControl.LevelFailed -= ShowLosePanel;
            Invoke(nameof(ActivateWinPanel), 2f);
        }

        public void ShowLosePanel()
        {
            _levelControl.LevelDone -= ShowWinPanel;
            Invoke(nameof(ActivateLoosePanel), 2f);
        }

        private void ActivateWinPanel()
        {
            _winPanel.SetActive(true);
            _level.SetActive(false);
        }

        private void ActivateLoosePanel()
        {
            _losePanel.SetActive(true);
            _level.SetActive(false);
        }

        public void ToNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        }

        public void PlayeAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}