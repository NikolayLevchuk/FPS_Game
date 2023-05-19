using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ChooseLevel : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button[] _levels;
        private int _unlockedLevel;

        public int UnlockedtLevel
        {
            get => _unlockedLevel;
            set
            {
                _unlockedLevel = value;
            }
        }

        private void OnEnable()
        {
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }

        private void Start()
        {
            UnlockedtLevel = PlayerPrefs.GetInt("Levels", 1);

            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i].interactable = false;
            }

            for (int i = 0; i < UnlockedtLevel; i++)
            {
                _levels[i].interactable = true;
            }
        }

        private void OnDisable()
        {
            _backToMenuButton.onClick.RemoveListener(BackToMenu);
        }

        public void LoadLevel(int levelNumber)
        {
            SceneManager.LoadScene(levelNumber);
        }

        public void BackToMenu()
        {
            _menuPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}