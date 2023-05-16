using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score = 0;
    private Transform CameraFollowObject;


    // Start is called before the first frame update
    void Start()
    {
        CameraFollowObject = GameObject.Find("CameraFollowObject").GetComponent<Transform>();
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt(CameraFollowObject.position.y);
        ScoreText.text = score.ToString() + "m";
    }

    public void StoreScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
