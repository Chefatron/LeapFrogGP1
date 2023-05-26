using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    private bool Paused = false;
    public GameObject PausePanel;
    public TextMeshProUGUI ScoreText;

    public void Start()
    {
        PausePanel.SetActive(false);
    }

    public void PauseButton()
    {
        if(Paused)
        {
            Time.timeScale = 1;
            Paused = false;
            PausePanel.SetActive(false);
        }
        else
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            Paused = true;
        }
    }

    public void ResetButton()
    {
        Time.timeScale = 1;
        Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        Paused = false;
        SceneManager.LoadScene(1);
    }
}
