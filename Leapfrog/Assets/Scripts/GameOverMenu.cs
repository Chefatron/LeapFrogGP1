using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }


    public void ResetButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousLevel"));
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(1);
    }
}
