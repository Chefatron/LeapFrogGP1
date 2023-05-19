using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartButtonObject;
    public GameObject Level1ButonObject;
    public GameObject Level2ButonObject;
    public GameObject Level3ButonObject;
    public GameObject SettingsPanel;

    private bool SettingsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        StartButtonObject.SetActive(true);
        Level1ButonObject.SetActive(false);
        Level2ButonObject.SetActive(false);
        Level3ButonObject.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    public void StartButton()
    {
        StartButtonObject.SetActive(false);
        Level1ButonObject.SetActive(true);
        Level2ButonObject.SetActive(true);
        Level3ButonObject.SetActive(true);
    }

    public void SelectLevel(int _Selection)
    {
        SceneManager.LoadScene(_Selection);
    }

    public void SettingsButton()
    {
        if(SettingsOpen)
        {
            SettingsPanel.SetActive(false);
            SettingsOpen = false;
        }
        else
        {
            SettingsPanel.SetActive(true);
            SettingsOpen = true;
        }
    }

    public void ResetTutorialButton()
    {
        PlayerPrefs.SetString("TutorialCompleted", "No");
    }
}
