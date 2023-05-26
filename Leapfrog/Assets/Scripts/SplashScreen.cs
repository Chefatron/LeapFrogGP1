using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float SplashTimer;
    private float CurrentSplashTime;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            SceneManager.LoadScene(1);
        }
        if(CurrentSplashTime < SplashTimer)
        {
            CurrentSplashTime += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
