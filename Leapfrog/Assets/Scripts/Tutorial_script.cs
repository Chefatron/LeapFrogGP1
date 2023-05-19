using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Tutorial_script : MonoBehaviour
{
    public GameObject PauseButton;
    private TextMeshProUGUI tutorialText;
    private int stage;
    float tutorialTimer;

    // Start is called before the first frame update
    void Start()
    {
        PauseButton.SetActive(false);
        tutorialText = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
        Time.timeScale = 0.01f;
        stage = 0;
        tutorialTimer = 0.003f;
        if (PlayerPrefs.GetString("TutorialCompleted") == "Yes")
        {
            Destroy(GameObject.Find("TutorialText"));
            Destroy(GameObject.Find("SkipButton"));
            Time.timeScale = 1;
            PauseButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount > 0 && tutorialTimer <= 0) || (Input.GetKey("space") && tutorialTimer <= 0))
        {
            switch (stage)
            {
                case 0:
                    Time.timeScale = 1;
                    tutorialText.text = "You will always be jumping";
                    stage++;
                    Time.timeScale = 0.01f;
                    break;
                case 1:
                    Time.timeScale = 1;
                    tutorialText.text = "Press the left of the screen to move left \n Press the right of the screen to move right";
                    stage++;
                    Time.timeScale = 0.01f;
                    break;
                case 2:
                    Time.timeScale = 1;
                    tutorialText.text = "Avoid obstacles and climb the tree, good luck";
                    stage++;
                    PlayerPrefs.SetString("TutorialCompleted", "Yes");
                    Time.timeScale = 0.01f;
                    break;
                case 3:
                    Time.timeScale = 1;
                    Destroy(GameObject.Find("TutorialText"));
                    Destroy(GameObject.Find("SkipButton"));
                    PauseButton.SetActive(true);
                    break;

            }
            tutorialTimer = 0.003f;
        }
        tutorialTimer -= Time.deltaTime;
    }

    public void SkipButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("TutorialCompleted", "Yes");
        Destroy(GameObject.Find("TutorialText"));
        Destroy(GameObject.Find("SkipButton"));
        PauseButton.SetActive(true);
    }
}
