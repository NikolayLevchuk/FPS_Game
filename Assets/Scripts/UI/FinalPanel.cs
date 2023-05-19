using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class FinalPanel : MonoBehaviour
    {
        [SerializeField] private Button _toMainMenu;

        private void OnEnable()
        {
            _toMainMenu.onClick.AddListener(BackToMenu);
        }
        private void OnDisable()
        {
            _toMainMenu.onClick.RemoveAllListeners();
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        }
    }
}