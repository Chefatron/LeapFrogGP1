using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class SoundSlider : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string FXPref = "FXPref";
    private int firstPlayInt;
    public Slider backgroundSlider, fxSlider;
    private float backgroundFloat, fxFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] fxAudio;
   
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = .75f;
            fxFloat = .50f;
            backgroundSlider.value = backgroundFloat;
            fxSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(FXPref, fxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            fxFloat = PlayerPrefs.GetFloat(FXPref);
            fxSlider.value = fxFloat;
        }
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
        PlayerPrefs.SetFloat(FXPref, fxFloat);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSound();
        }
        
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i = 0; i < fxAudio.Length; i++)
        {
            fxAudio[i].volume = fxSlider.value;
        }
    }
}

