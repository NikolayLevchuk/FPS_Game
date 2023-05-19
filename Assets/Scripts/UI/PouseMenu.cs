using Assets.Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PouseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button _resumeGame;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _quitGame;

    public static bool GameIsPaused = false;

    private void OnEnable()
    {
        _resumeGame.onClick.AddListener(Resume);
        _mainMenu.onClick.AddListener(LoadMenu);
        _quitGame.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _resumeGame.onClick.RemoveListener(Resume);
        _mainMenu.onClick.RemoveListener(LoadMenu);
        _quitGame.onClick.RemoveListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (GameIsPaused)
                Resume();
            else
                Pause();
    }

    public void OpenPausePanel()
    {
        if (GameIsPaused)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        GetComponentInParent<PlayerController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GetComponentInParent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
