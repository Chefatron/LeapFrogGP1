using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MasterVolume : MonoBehaviour
{
    public AudioMixer[] mixer;


    public void SetLevel (float slidervalue)
    {
        
        for (int i = 0; i < mixer.Length; i++)
        {
            mixer[i].SetFloat("MasterVol", Mathf.Log10(slidervalue) * 20);
        }
    }
}
