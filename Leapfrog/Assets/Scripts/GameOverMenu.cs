using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousLevel"));
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
